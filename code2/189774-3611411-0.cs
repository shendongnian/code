    using Microsoft.Deployment.WindowsInstaller;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using( var database = new Database(@"C:\orca.msi", DatabaseOpenMode.Direct  ))
                {
                    database.SummaryInfo.Template = "Intel;666";
                }            
            }
        }
    }
