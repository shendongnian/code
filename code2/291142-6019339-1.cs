        string path1 =  @"c:\directory\";
        string path2 = @"c:\directory\file.txt";
        string path3 = @"c:\directory";
        string dir;
        string file;
        string result;
            dir = System.IO.Path.GetDirectoryName(path1);
            file = System.IO.Path.GetFileName(path1);
            if (String.IsNullOrEmpty(file))
            {
                result = dir;
            }
            else {
                result = System.IO.Path.Combine(dir, file);
            }
            Console.WriteLine(result);
            dir = System.IO.Path.GetDirectoryName(path2);
            file = System.IO.Path.GetFileName(path2);
            if (String.IsNullOrEmpty(file))
            {
                result = dir;
            }
            else
            {
                result = System.IO.Path.Combine(dir, file);
            }
            Console.WriteLine(result);
            dir = System.IO.Path.GetDirectoryName(path3);
            file = System.IO.Path.GetFileName(path3);
            if (String.IsNullOrEmpty(file))
            {
                result = dir;
            }
            else
            {
                result = System.IO.Path.Combine(dir, file);
            }
            Console.WriteLine(result);
