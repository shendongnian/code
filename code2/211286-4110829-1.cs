    using System;
    using System.Linq;
    using Microsoft.Web.Administration;
    
    namespace ListRootAppPathsIIS7
    {
      class Program
      {
        static void Main(string[] args)
        {
          using(ServerManager serverManager = new ServerManager())
          {
            foreach (var site in serverManager.Sites)
            {
              var app = site.Applications.Where(a => a.Path == "/").First();
              var vdir = app.VirtualDirectories.Where(v => v.Path == "/").First();
              string info = String.Format("{0} - {1} - {2}", 
                  site.Id, 
                  site.Name, 
                  Environment.ExpandEnvironmentVariables(vdir.PhysicalPath));
            
              Console.WriteLine(info);
            }
          }
          Console.ReadLine();
    
        }
      }
    }
