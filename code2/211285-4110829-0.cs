    using System;
    using System.DirectoryServices;
    
    namespace ListRootAppPathsIIS6
    {
      class Program
      {
        static void Main(string[] args)
        {
          using (DirectoryEntry de = new DirectoryEntry("IIS://Localhost/W3SVC"))
          {
            foreach (DirectoryEntry w3svc in de.Children)
            {
              if (w3svc.SchemaClassName == "IIsWebServer")
              {
                string rootPath = 
                    String.Format("IIS://Localhost/W3SVC/{0}/root", w3svc.Name);
                using (DirectoryEntry root = new DirectoryEntry(rootPath))
                {
                  string info = String.Format("{0} - {1} - {2}", 
                      w3svc.Name, 
                      w3svc.Properties["ServerComment"].Value, 
                      root.Properties["Path"].Value);
                      
                  Console.WriteLine(info);
                }
              }
            }
          }
    
          Console.ReadLine();
        }
      }
    }
