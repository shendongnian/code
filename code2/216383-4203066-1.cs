    List<string> list;
    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
    protected void Page_Load(object sender, EventArgs e)
    {
        list = Enumerable.Range(0, 15000).Select(i => i.ToString()).ToList();
        UsingStrings();
        UsingStringBuilder();
        UsingXDocument();
    }
    private void UsingStrings()
    {
        timer.Reset();
        timer.Start();
        string beginItemNode = "<Node>";
        string endItemNode = "</Node>";
        string xml = "<Root>";
        foreach (string item in list)
        {
            xml += beginItemNode + item + endItemNode;
        }
        xml += "</Root>";
        timer.Stop();
        Response.Write(string.Format("Strings time:{0}<br />", timer.Elapsed.Ticks));
    }
    private void UsingStringBuilder()
    {
        timer.Reset();
        timer.Start();
        StringBuilder sb = new StringBuilder();
        sb.Append("<Root>");
        foreach (string item in list)
        {
            sb.AppendFormat("<Node>{0}</Node>", item);
        }
        sb.Append("</Root>");
        timer.Stop();
        Response.Write(string.Format("StringBuilder time:{0}<br />", timer.Elapsed.Ticks));
    }
    private void UsingXDocument()
    {
        timer.Reset();
        timer.Start();
        XDocument xDoc = new XDocument();
        xDoc.Add(new XElement("Root"));
        foreach (var item in list)
        {
            XElement element = new XElement("Node", item);
            xDoc.Root.Add(element);
        }
        timer.Stop();
        Response.Write(string.Format("XDocument time:{0}<br />", timer.Elapsed.Ticks));
    }
