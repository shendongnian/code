    string[] a1 = new string[] { "Text1", "Text2" };
    string[] a2 = new string[] { "Another Text1", "Another Text2" };
    List<string> list = new List<string>();
    list.AddRange(a1);
    list.AddRange(a2);
    using (FileStream str = new FileInfo(@"C:\MyFilePath.txt").OpenWrite())
    {
        StreamWriter writter = new StreamWriter(str);
        writter.Write(string.Join(Environment.NewLine, list));
        writter.Close();
    }
