        public static bool CheckFiles(string pathA, string pathB)
        {
            string[] extantionFormat = new string[] { ".war", ".pkg" };
            return CheckFiles(pathA, pathB, extantionFormat);
        }
        public static bool CheckFiles(string pathA, string pathB, string[] extantionFormat)
        {
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(pathA);
            System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(pathB);
            // Take a snapshot of the file system. list1/2 will contain only WAR or PKG 
            // files
            // fileInfosA will contain all of files under path directories 
            FileInfo[] fileInfosA = dir1.GetFiles("*.*", 
                                  System.IO.SearchOption.AllDirectories);
            // list will contain all of files that have ..extantion[]  
            // Run on all extantion in extantion array and compare them by lower case to 
            // the file item extantion ...
            List<System.IO.FileInfo> list1 = (from extItem in extantionFormat
                                              from fileItem in fileInfosA
                                              where extItem.ToLower().Equals 
                                              (fileItem.Extension.ToLower())
                                              select fileItem).ToList();
            // Take a snapshot of the file system. list1/2 will contain only WAR or  
            // PKG files
            // fileInfosA will contain all of files under path directories 
            FileInfo[] fileInfosB = dir2.GetFiles("*.*", 
                                           System.IO.SearchOption.AllDirectories);
            // list will contain all of files that have ..extantion[]  
            // Run on all extantion in extantion array and compare them by lower case to 
            // the file item extantion ...
            List<System.IO.FileInfo> list2 = (from extItem in extantionFormat
                                              from fileItem in fileInfosB
                                              where extItem.ToLower().Equals            
                                              (fileItem.Extension.ToLower())
                                              select fileItem).ToList();
            FileCompare myFileCompare = new FileCompare();
            // This query determines whether the two folders contain 
            // identical file lists, based on the custom file comparer 
            // that is defined in the FileCompare class. 
            return list1.SequenceEqual(list2, myFileCompare);
        }
