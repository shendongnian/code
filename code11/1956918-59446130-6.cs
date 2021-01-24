    //Async Task that performs long operations that could Block UI
    private Async Task SubsceneCore()
    {
        ItemResult = new ObservableCollection<ItemResultModel>();
        try
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(lstSearch.SelectedItems[0]);
    
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//table[1]//tbody");
    
            foreach ((var cell, int index) in table.SelectNodes(".//tr/td").WithIndex())
            {
                var Name = doc.DocumentNode.SelectNodes(".//tr/td//span[2]")[index].InnerText;
                ......
                ......
    
                //get poster img
                HtmlNode img = doc.DocumentNode.SelectSingleNode("//div[@class='poster']//img");
    
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(img.GetAttributeValue("src", "pack://application:,,,/SubtitleDownloader;component/Resources/Img/notfound.png"), UriKind.Absolute);
                bitmap.EndInit();
    
                poster.Source = bitmap;
    
                ItemResultModel item = new ItemResultModel { Name = Name, Translator = Comment, Link = Link, Language = GlobalData.Config.SubtitleLang };
                ItemResult.Add(item);
    
            }
        }
        catch (ArgumentOutOfRangeException)
        {
    
        }
        catch (ArgumentNullException) { }
    }
    //Calling Async Task 
    private void button1_Click(object sender, EventArgs e)
    {
      await SubsceneCore();
    }
