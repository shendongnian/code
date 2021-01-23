    private string ReadPage(string Link)
    {
      using (var client = new WebClient())
      {
        this.wbrwPages.Navigate(Link);
        while (this.wbrwPages.ReadyState != WebBrowserReadyState.Complete)
        {
          Application.DoEvents();
        }
        ReadPage = this.wbrwPages.DocumentText;
      }
    }
