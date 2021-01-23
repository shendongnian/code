    using System;
    using System.Linq;
    using System.Runtime.Versioning;
    using NuGet;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var frameworkName = new FrameworkName(".NETFramework, Version=4.0");
            var repository = new LocalPackageRepository(@"C:\Users\ggherardi\AppData\Local\NuGet\Cache");
            const bool prerelease = false;
            var packages = repository.GetPackages()
                .Where(p => prerelease ? p.IsAbsoluteLatestVersion : p.IsLatestVersion)
                .Where(p => VersionUtility.IsCompatible(frameworkName, p.GetSupportedFrameworks()));
            foreach (IPackage package in packages)
            {
                GetValue(repository, frameworkName, package, prerelease, 0);
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }
        private static void GetValue(IPackageRepository repository, FrameworkName frameworkName, IPackage package, bool prerelease, int level)
        {
            
            Console.WriteLine("{0}{1}", new string(' ', level * 3), package);
            foreach (PackageDependency dependency in package.GetCompatiblePackageDependencies(frameworkName))
            {
                IPackage subPackage = repository.ResolveDependency(dependency, prerelease, true);
                GetValue(repository, frameworkName, subPackage, prerelease, ++level);
            }
        }
    }
