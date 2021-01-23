    [MTAThread]
    static void Main()
    {
        var name = "\\foo.txt";
        var info = new FileInfo(name);
        using (info.Create()) { }
        info.Refresh();
        var createTime = info.CreationTime;
        var now = DateTime.Now;
        var delta = now - createTime;
        Debug.WriteLine(delta.ToString());
    }
