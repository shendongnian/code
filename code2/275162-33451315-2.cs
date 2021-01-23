    using System.IO;
    internal static class DirectoryInfoExt
    {
        internal static bool IsSubDirectoryOfOrSame(this DirectoryInfo directoryInfo, DirectoryInfo potentialParent)
        {
            if (DirectoryInfoComparer.Default.Equals(directoryInfo, potentialParent))
            {
                return true;
            }
            return IsStrictSubDirectoryOf(directoryInfo, potentialParent);
        }
        internal static bool IsStrictSubDirectoryOf(this DirectoryInfo directoryInfo, DirectoryInfo potentialParent)
        {
            while (directoryInfo.Parent != null)
            {
                if (DirectoryInfoComparer.Default.Equals(directoryInfo.Parent, potentialParent))
                {
                    return true;
                }
                directoryInfo = directoryInfo.Parent;
            }
            return false;
        }
    }
<!>
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class DirectoryInfoComparer : IEqualityComparer<DirectoryInfo>
    {
        private static readonly char[] TrimEnd = { '\\' };
        public static readonly DirectoryInfoComparer Default = new DirectoryInfoComparer();
        private static readonly StringComparer OrdinalIgnoreCaseComparer = StringComparer.OrdinalIgnoreCase;
        private DirectoryInfoComparer()
        {
        }
        public bool Equals(DirectoryInfo x, DirectoryInfo y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return OrdinalIgnoreCaseComparer.Equals(x.FullName.TrimEnd(TrimEnd), y.FullName.TrimEnd(TrimEnd));
        }
        public int GetHashCode(DirectoryInfo obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            return OrdinalIgnoreCaseComparer.GetHashCode(obj.FullName.TrimEnd(TrimEnd));
        }
    }
