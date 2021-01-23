    public static void Main()
    {
        //D:Dir dhould exists in ur system
        DirectoryInfo dir1 = new DirectoryInfo(@"D:Dir");
        FileInfo [] files = dir1.GetFiles("*xls", SearchOption.AllDirectories);
        foreach (FileInfo f in files)
        {
            string filename = f.Name.ToString();
            filename= filename.Replace(".xls", "");
            Console.WriteLine(filename);
        }
        Console.ReadKey();
       
    }
}
