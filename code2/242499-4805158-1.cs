    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace DocumentDistributor.Library
    {
        public static class myExtensions
        {
            public static string[] GetFileNamesWithoutFileExtensions(this DirectoryInfo di)
            {
                FileInfo[] fi = di.GetFiles();
                List<string> returnValue = new List<string>();
    
                for (int i = 0; i < fi.Length; i++)
                {
                    returnValue.Add(Path.GetFileNameWithoutExtension(fi[i].FullName)); 
                }
    
                return returnValue.ToArray<string>();
             }
        }
    }
