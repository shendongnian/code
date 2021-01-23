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
    internal class DirectoryInfoComparer : IEqualityComparer<DirectoryInfo>
    {
        private static readonly char[] TrimEnd = { '\\' };
        public static readonly DirectoryInfoComparer Default = new DirectoryInfoComparer();
        private DirectoryInfoComparer()
        {
        }
        public bool Equals(DirectoryInfo x, DirectoryInfo y)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(x.FullName.TrimEnd(TrimEnd), y.FullName.TrimEnd(TrimEnd));
        }
        public int GetHashCode(DirectoryInfo obj)
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.FullName.TrimEnd(TrimEnd));
        }
    }
