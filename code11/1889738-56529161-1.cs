    using Shell32;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    namespace ConsoleApplication1101
    {
        class Program
        {
            [STAThread()]
            static void Main(string[] args)
            {
                // create shell
                var shell = new Shell();
    
                // get recycler folder
                var recyclerFolder = shell.NameSpace(10);
    
                // for each files
                for (int i = 0; i < recyclerFolder.Items().Count; i++)
                {
                    // get the folder item
                    var folderItems = recyclerFolder.Items().Item(i);
    
                    // get file name
                    var filename = recyclerFolder.GetDetailsOf(folderItems, 0);
                  
                    // write file path to console
                    Console.WriteLine(filename);
                }
            }
        }
    }
