    public static async Task<HtmlDocument> PageParse()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = await web.LoadFromWebAsync(UrlText.Text);
        return doc;
    }
and your CrawdBtn_Click method would look like this.
    private void CrawdBtn_Click(object sender, EventArgs e)
    {
        t = PageParse();
        t.Wait(); // t.Wait() is needed to start the async call. await can only be used within async methods
        //Do what you need to do with t.Result / t.Result.DocumentNode
        // I dont know what EnqueuedFromList is..
        b = new Task(EnqueueFromList);
        b.Start();
        //Task.WaitAll(t,b);
        CrawdBtn.Enabled = true;
    }
