    public List<string> ReturnsAllTextEnteredOnPage()
    {
      List<string> allTextEnteredOnPage = new List<string>();
      var allControls = FlattenChildren(Page);
      var allTextControls = allControls.OfType<TextBox>();
      foreach(var textCtrl in allTextControls)
      {
         allTextEnteredOnPage.Add(Server.HtmlEncode(textCtrl.Text));
      }
      return allTextEnteredOnPage;        
    }
