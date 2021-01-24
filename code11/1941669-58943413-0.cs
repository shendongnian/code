    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Text;
    using static System.IO.Path;
    static class PathExtension
    {
        // Port of .net 3.0 Path.GetRelativePath (Windows version)
        // https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getrelativepath?view=netcore-3.0
        // 
        // Adapted from:
        // https://github.com/dotnet/corefx/blob/b123ba4b9107c73cbc02010dc1ee78eb8ffccb93/src/Common/src/CoreLib/System/IO/Path.cs
        // https://github.com/dotnet/corefx/blob/4a7075f188b5777ccb519f2af9b8a284f4383357/src/Common/src/CoreLib/System/IO/Path.Windows.cs
        //
        // Notes:
        // * I didn't have access to ReadOnlySpan<T> nor .AsSpan(), so I removed them.  I just used regular string instead.
        // * I hard coded some resource strings (from exceptions)
        // * Replaced ValueStringBuild with StringBuilder
        /// <summary>
        /// Create a relative path from one path to another. Paths will be resolved before calculating the difference.
        /// Default path comparison for the active platform will be used (OrdinalIgnoreCase for Windows or Mac, Ordinal for Unix).
        /// </summary>
        /// <param name="relativeTo">The source path the output should be relative to. This path is always considered to be a directory.</param>
        /// <param name="path">The destination path.</param>
        /// <returns>The relative path or <paramref name="path"/> if the paths don't share the same root.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="relativeTo"/> or <paramref name="path"/> is <c>null</c> or an empty string.</exception>
        public static string GetRelativePath(string relativeTo, string path)
        {
            return GetRelativePath(relativeTo, path, StringComparison);
        }
        private static string GetRelativePath(string relativeTo, string path, StringComparison comparisonType)
        {
            if (relativeTo == null)
                throw new ArgumentNullException(nameof(relativeTo));
            if (PathInternal.IsEffectivelyEmpty(relativeTo.AsSpan()))
                throw new ArgumentException(SR.Arg_PathEmpty, nameof(relativeTo));
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (PathInternal.IsEffectivelyEmpty(path.AsSpan()))
                throw new ArgumentException(SR.Arg_PathEmpty, nameof(path));
            Debug.Assert(comparisonType == StringComparison.Ordinal || comparisonType == StringComparison.OrdinalIgnoreCase);
            relativeTo = GetFullPath(relativeTo);
            path = GetFullPath(path);
            // Need to check if the roots are different- if they are we need to return the "to" path.
            if (!PathInternal.AreRootsEqual(relativeTo, path, comparisonType))
                return path;
            int commonLength = PathInternal.GetCommonPathLength(relativeTo, path, ignoreCase: comparisonType == StringComparison.OrdinalIgnoreCase);
            // If there is nothing in common they can't share the same root, return the "to" path as is.
            if (commonLength == 0)
                return path;
            // Trailing separators aren't significant for comparison
            int relativeToLength = relativeTo.Length;
            if (EndsInDirectorySeparator(relativeTo.AsSpan()))
                relativeToLength--;
            bool pathEndsInSeparator = EndsInDirectorySeparator(path.AsSpan());
            int pathLength = path.Length;
            if (pathEndsInSeparator)
                pathLength--;
            // If we have effectively the same path, return "."
            if (relativeToLength == pathLength && commonLength >= relativeToLength) return ".";
            // We have the same root, we need to calculate the difference now using the
            // common Length and Segment count past the length.
            //
            // Some examples:
            //
            //  C:\Foo C:\Bar L3, S1 -> ..\Bar
            //  C:\Foo C:\Foo\Bar L6, S0 -> Bar
            //  C:\Foo\Bar C:\Bar\Bar L3, S2 -> ..\..\Bar\Bar
            //  C:\Foo\Foo C:\Foo\Bar L7, S1 -> ..\Bar
            // Original: var sb = new ValueStringBuilder(stackalloc char[260]);
            var sb = new StringBuilder(260);
            sb.EnsureCapacity(Math.Max(relativeTo.Length, path.Length));
            // Add parent segments for segments past the common on the "from" path
            if (commonLength < relativeToLength)
            {
                sb.Append("..");
                for (int i = commonLength + 1; i < relativeToLength; i++)
                {
                    if (PathInternal.IsDirectorySeparator(relativeTo[i]))
                    {
                        sb.Append(DirectorySeparatorChar);
                        sb.Append("..");
                    }
                }
            }
            else if (PathInternal.IsDirectorySeparator(path[commonLength]))
            {
                // No parent segments and we need to eat the initial separator
                //  (C:\Foo C:\Foo\Bar case)
                commonLength++;
            }
            // Now add the rest of the "to" path, adding back the trailing separator
            int differenceLength = pathLength - commonLength;
            if (pathEndsInSeparator)
                differenceLength++;
            if (differenceLength > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(DirectorySeparatorChar);
                }
                sb.Append(path.AsSpan(commonLength, differenceLength));
            }
            return sb.ToString();
        }
        /// <summary>Returns a comparison that can be used to compare file and directory names for equality.</summary>
        internal static StringComparison StringComparison =>
            IsCaseSensitive ?
                StringComparison.Ordinal :
                StringComparison.OrdinalIgnoreCase;
        /// <summary>
        /// Returns true if the path ends in a directory separator.
        /// </summary>
        public static bool EndsInDirectorySeparator(string path) // Originally was public static bool EndsInDirectorySeparator(ReadOnlySpan<char> path)
            => path.Length > 0 && PathInternal.IsDirectorySeparator(path[path.Length - 1]);
        #region Resources
        // From https://github.com/dotnet/corefx/blob/c390ce7df50252e11f5d322276e9d19e046d1332/src/Microsoft.IO.Redist/src/Resources/Strings.resx
        static class SR
        {
            public static string Arg_PathEmpty => "The path is empty.";
        }
        #endregion Resources
        #region Path.Windows 
        // Code from 
        // https://github.com/dotnet/corefx/blob/4a7075f188b5777ccb519f2af9b8a284f4383357/src/Common/src/CoreLib/System/IO/Path.Windows.cs
        // https://github.com/dotnet/corefx/blob/4a7075f188b5777ccb519f2af9b8a284f4383357/src/Common/src/CoreLib/System/IO/Path.Windows.cs#L235
        /// <summary>Gets whether the system is case-sensitive.</summary>
        internal static bool IsCaseSensitive => false;
        #endregion Path.Windows
        #region Workarounds
        // Note, this is here just to cause all .AsSpan() calls to return a string since I don't have access to ReadOnlySpan<char>
        // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.primitives.stringsegment.asspan?view=dotnet-plat-ext-3.0
        static string AsSpan(this string s)
        {
            return s;
        }
        // Note, this is here just to cause all .AsSpan() calls to return a string since I don't have access to ReadOnlySpan<char>
        // https://docs.microsoft.com/en-us/dotnet/api/system.memoryextensions.asspan?view=netcore-3.0#System_MemoryExtensions_AsSpan_System_String_System_Int32_System_Int32_
        static string AsSpan(this string s, int startIndex, int length)
        {
            return s.Substring(startIndex, length);
        }
        #endregion Workarounds
        // Code from 
        // https://github.com/dotnet/corefx/blob/b123ba4b9107c73cbc02010dc1ee78eb8ffccb93/src/Common/src/CoreLib/System/IO/PathInternal.cs
        // https://github.com/dotnet/corefx/blob/b123ba4b9107c73cbc02010dc1ee78eb8ffccb93/src/Common/src/CoreLib/System/IO/PathInternal.Windows.cs
        static class PathInternal
        {
            /// <summary>
            /// Returns true if the two paths have the same root
            /// </summary>
            internal static bool AreRootsEqual(string first, string second, StringComparison comparisonType)
            {
                int firstRootLength = GetRootLength(first.AsSpan());
                int secondRootLength = GetRootLength(second.AsSpan());
                return firstRootLength == secondRootLength
                    && string.Compare(
                        strA: first,
                        indexA: 0,
                        strB: second,
                        indexB: 0,
                        length: firstRootLength,
                        comparisonType: comparisonType) == 0;
            }
            #region PathInternal.Windows
            // Code from https://github.com/dotnet/corefx/blob/b123ba4b9107c73cbc02010dc1ee78eb8ffccb93/src/Common/src/CoreLib/System/IO/PathInternal.Windows.cs
            // \\?\, \\.\, \??\
            internal const int DevicePrefixLength = 4;
            // \\
            internal const int UncPrefixLength = 2;
            // \\?\UNC\, \\.\UNC\
            internal const int UncExtendedPrefixLength = 8;
            /// <summary>
            /// Returns true if the given character is a valid drive letter
            /// </summary>
            internal static bool IsValidDriveChar(char value)
            {
                return (value >= 'A' && value <= 'Z') || (value >= 'a' && value <= 'z');
            }
            /// <summary>
            /// True if the given character is a directory separator.
            /// </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool IsDirectorySeparator(char c)
            {
                return c == DirectorySeparatorChar || c == AltDirectorySeparatorChar;
            }
            /// <summary>
            /// Returns true if the path uses the canonical form of extended syntax ("\\?\" or "\??\"). If the
            /// path matches exactly (cannot use alternate directory separators) Windows will skip normalization
            /// and path length checks.
            /// </summary>
            internal static bool IsExtended(string path) // Original was internal static bool IsExtended(ReadOnlySpan<char> path)
            {
                // While paths like "//?/C:/" will work, they're treated the same as "\\.\" paths.
                // Skipping of normalization will *only* occur if back slashes ('\') are used.
                return path.Length >= DevicePrefixLength
                    && path[0] == '\\'
                    && (path[1] == '\\' || path[1] == '?')
                    && path[2] == '?'
                    && path[3] == '\\';
            }
            /// <summary>
            /// Returns true if the path uses any of the DOS device path syntaxes. ("\\.\", "\\?\", or "\??\")
            /// </summary>
            internal static bool IsDevice(string path) // Original was: internal static bool IsDevice(ReadOnlySpan<char> path)
            {
                // If the path begins with any two separators is will be recognized and normalized and prepped with
                // "\??\" for internal usage correctly. "\??\" is recognized and handled, "/??/" is not.
                return IsExtended(path)
                    ||
                    (
                        path.Length >= DevicePrefixLength
                        && IsDirectorySeparator(path[0])
                        && IsDirectorySeparator(path[1])
                        && (path[2] == '.' || path[2] == '?')
                        && IsDirectorySeparator(path[3])
                    );
            }
            /// <summary>
            /// Returns true if the path is a device UNC (\\?\UNC\, \\.\UNC\)
            /// </summary>
            internal static bool IsDeviceUNC(string path) // Original was: internal static bool IsDeviceUNC(ReadOnlySpan<char> path) 
            {
                return path.Length >= UncExtendedPrefixLength
                    && IsDevice(path)
                    && IsDirectorySeparator(path[7])
                    && path[4] == 'U'
                    && path[5] == 'N'
                    && path[6] == 'C';
            }
            /// <summary>
            /// Gets the length of the root of the path (drive, share, etc.).
            /// </summary>
            internal static int GetRootLength(string path) // Note: original was internal static int GetRootLength(ReadOnlySpan<char> path)
            {
                int pathLength = path.Length;
                int i = 0;
                bool deviceSyntax = IsDevice(path);
                bool deviceUnc = deviceSyntax && IsDeviceUNC(path);
                if ((!deviceSyntax || deviceUnc) && pathLength > 0 && IsDirectorySeparator(path[0]))
                {
                    // UNC or simple rooted path (e.g. "\foo", NOT "\\?\C:\foo")
                    if (deviceUnc || (pathLength > 1 && IsDirectorySeparator(path[1])))
                    {
                        // UNC (\\?\UNC\ or \\), scan past server\share
                        // Start past the prefix ("\\" or "\\?\UNC\")
                        i = deviceUnc ? UncExtendedPrefixLength : UncPrefixLength;
                        // Skip two separators at most
                        int n = 2;
                        while (i < pathLength && (!IsDirectorySeparator(path[i]) || --n > 0))
                            i++;
                    }
                    else
                    {
                        // Current drive rooted (e.g. "\foo")
                        i = 1;
                    }
                }
                else if (deviceSyntax)
                {
                    // Device path (e.g. "\\?\.", "\\.\")
                    // Skip any characters following the prefix that aren't a separator
                    i = DevicePrefixLength;
                    while (i < pathLength && !IsDirectorySeparator(path[i]))
                        i++;
                    // If there is another separator take it, as long as we have had at least one
                    // non-separator after the prefix (e.g. don't take "\\?\\", but take "\\?\a\")
                    if (i < pathLength && i > DevicePrefixLength && IsDirectorySeparator(path[i]))
                        i++;
                }
                else if (pathLength >= 2
                    && path[1] == VolumeSeparatorChar
                    && IsValidDriveChar(path[0]))
                {
                    // Valid drive specified path ("C:", "D:", etc.)
                    i = 2;
                    // If the colon is followed by a directory separator, move past it (e.g "C:\")
                    if (pathLength > 2 && IsDirectorySeparator(path[2]))
                        i++;
                }
                return i;
            }
            /// <summary>
            /// Gets the count of common characters from the left optionally ignoring case
            /// </summary>
            internal static unsafe int EqualStartingCharacterCount(string first, string second, bool ignoreCase)
            {
                if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second)) return 0;
                int commonChars = 0;
                fixed (char* f = first)
                fixed (char* s = second)
                {
                    char* l = f;
                    char* r = s;
                    char* leftEnd = l + first.Length;
                    char* rightEnd = r + second.Length;
                    while (l != leftEnd && r != rightEnd
                        && (*l == *r || (ignoreCase && char.ToUpperInvariant(*l) == char.ToUpperInvariant(*r))))
                    {
                        commonChars++;
                        l++;
                        r++;
                    }
                }
                return commonChars;
            }
            /// <summary>
            /// Get the common path length from the start of the string.
            /// </summary>
            internal static int GetCommonPathLength(string first, string second, bool ignoreCase)
            {
                int commonChars = EqualStartingCharacterCount(first, second, ignoreCase: ignoreCase);
                // If nothing matches
                if (commonChars == 0)
                    return commonChars;
                // Or we're a full string and equal length or match to a separator
                if (commonChars == first.Length
                    && (commonChars == second.Length || IsDirectorySeparator(second[commonChars])))
                    return commonChars;
                if (commonChars == second.Length && IsDirectorySeparator(first[commonChars]))
                    return commonChars;
                // It's possible we matched somewhere in the middle of a segment e.g. C:\Foodie and C:\Foobar.
                while (commonChars > 0 && !IsDirectorySeparator(first[commonChars - 1]))
                    commonChars--;
                return commonChars;
            }
            /// <summary>
            /// Returns true if the path is effectively empty for the current OS.
            /// For unix, this is empty or null. For Windows, this is empty, null, or
            /// just spaces ((char)32).
            /// </summary>
            /// 
            internal static bool IsEffectivelyEmpty(string path)
            {
                // Note, see the original version below
                return string.IsNullOrWhiteSpace(path);
            }
            // Note: here's the original version.  I've replaced it with the version above that just uses string
            // 
            //internal static bool IsEffectivelyEmpty(ReadOnlySpan<char> path)
            //{
            //    if (path.IsEmpty)
            //        return true;
            //    foreach (char c in path)
            //    {
            //        if (c != ' ')
            //            return false;
            //    }
            //    return true;
            //}
            #endregion PathInternal.Windows
        }
    }
