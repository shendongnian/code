    string dirA = @"C:\";
    string dirB = @"D:\";
    string[] files = System.IO.Directory.GetFiles(dirA);
    foreach (string s in files) {
        if (System.IO.Path.GetExtension(s).equals("bak")) {
            System.IO.File.Copy(s, System.IO.Path.Combine(targetPath, fileName), true);
        }
    }
