    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace TestSubDirectories
    {
        class Program
        {
    
            static string NewFolderName = "NewFolder";
            static void Main(string[] args)
            {
    
                string path = "C:\\testfolder";
    
                if (Directory.Exists(path))
                    CreateSubFolderIn(path);
            }
    
    
            static void CreateSubFolderIn(string path)
            {
                foreach (string SubDirectory in Directory.GetDirectories(path))
                {
                    CreateSubFolderIn(SubDirectory);
                }
    
                if(!Directory.Exists(path + "\\" + NewFolderName))
                    Directory.CreateDirectory(path + "\\" + NewFolderName);
    
            }
    
        }
    }
