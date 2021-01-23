    class Program
    {
        static void Main(string[] args)
        {
            movedirfiles(@"E:\f1", @"E:\f2");
        }
        static void movedirfiles(string sourdir,string destdir)
        {
            string[] dirlist = Directory.GetDirectories(sourdir);
          
            moveallfiles(sourdir, destdir);
            if (dirlist!=null && dirlist.Count()>0)
            {
                foreach(string dir in dirlist)
                {
                    string dirName = destdir+"\\"+ new DirectoryInfo(dir).Name;
                    Directory.CreateDirectory(dirName);
                    moveallfiles(dir,dirName);
                }
            }
        }
        static void moveallfiles(string sourdir,string destdir)
        {
            string[] filelist = Directory.GetFiles(sourdir);
            if (filelist != null && filelist.Count() > 0)
            {
                foreach (string file in filelist)
                {
                    File.Copy(file, string.Concat(destdir, "\\"+Path.GetFileName(file)));
                }
            }
        }
      
    }
