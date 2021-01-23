public static void CopyFilesWithExtension(string src, string dst, string extension)
{
    string[] files = System.IO.Directory.GetFiles(src);
    foreach (string s in files)
    {
         if (System.IO.Path.GetExtension(s).Equals(extension))
         {
             var filename = System.IO.Path.GetFileName(s);
             System.IO.File.Copy(s, System.IO.Path.Combine(dst, filename));
         }
    }
}
Usage:
Utils.CopyFilesWithExtension(@"C:\src_folder",@"C:\dst_folder",".csv");
