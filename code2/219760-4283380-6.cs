    public Dictionary<string, string> ReturnsAllTextEnteredOnPage()
    {
       Dictionary<string, string> allTextEnteredOnPage = new Dictionary<string, string>(); 
       foreach (var control in Page.Controls)
       {
          if (control is TextBox)
          {
             TextBox ctrl = (TextBox)control;
             allTextEnteredOnPage.Add(ctrl.ID, Server.HtmlEncode(ctrl.Text));
          }
       }
       return allTextEnteredOnPage;
    }
