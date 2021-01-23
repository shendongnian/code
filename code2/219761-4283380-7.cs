    public Dictionary<string, string> ReturnsAllTextEnteredOnPage()
    {
      Dictionary<string, string> allTextEnteredOnPage = new Dictionary<string, string>(); 
      var allControls = FlattenChildren(Page);
      var allTextControls = allControls.OfType<TextBox>();
      foreach(var textCtrl in allTextControls)
      {
         allTextEnteredOnPage.Add(textCtrl.ID, Server.HtmlEncode(textCtrl.Text));
      }
      return allTextEnteredOnPage;        
    }
