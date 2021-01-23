    private List<Dictionary<string, string>> myList = new List<Dictionary<string, string>>();
    private int pageIndex = 0;
    private void PrintButton_Click(object sender, EventArgs e)
    {
        PrintDocument document = new PrintDocument();
        document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        document.Print();
    }
    
    void document_PrintPage(object sender, PrintPageEventArgs e)
    {
        if (pageIndex >= myList.Count)
        {
            e.HasMorePages = false;
            return;
        }
    
        Dictionary<string, string> curData = myList[pageIndex];
        List<string> lines = new List<string>();
        lines.Add("Items count: " + curData.Count);
        curData.Keys.ToList().ForEach(key =>
        {
            lines.Add(string.Format("Key: {0}, Value: {1}", key, curData[key]));
        });
        e.Graphics.DrawString(string.Join("\n", lines), this.Font, SystemBrushes.WindowText, 0, 0);
        pageIndex++;
        e.HasMorePages = pageIndex < myList.Count;
    }
