    using System;
    using System.Linq;
    using System.Reflection;
 
    public static class AssemblyExtensions
    {
        public static Version GetFileVersion(this Assembly assembly)
        {
            var versionString = assembly.GetCustomAttributes(false)
                .OfType<AssemblyFileVersionAttribute>()
                .First()
                .Version;
 
            return Version.Parse(versionString);
        }
    }
