    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NuGet;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {    
                var repo = new LocalPackageRepository(@"C:\Code\Common\Group\Business-Logic\packages");
                IQueryable<IPackage> packages = repo.GetPackages();
                OutputGraph(repo, packages, 0);
            }
    
            static void OutputGraph(LocalPackageRepository repository, IEnumerable<IPackage> packages, int depth)
            {
                foreach (IPackage package in packages)
                {
                    Console.WriteLine("{0}{1} v{2}", new string(' ', depth), package.Id, package.Version);
    
                    IList<IPackage> dependentPackages = new List<IPackage>();
                    foreach (var dependency in package.Dependencies)
                    {
                        dependentPackages.Add(repository.FindPackage(dependency.Id, dependency.VersionSpec.ToString()));
                    }
    
                    OutputGraph(repository, dependentPackages, depth += 3);
                }
            }
        }
    }
