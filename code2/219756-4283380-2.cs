    public List<string> ReturnsAllTextEnteredOnPage()
    {
       List<string> allTextEnteredOnPage = new List<string>();
       foreach (var control in Page.Controls)
       {
          if (control is TextBox)
          {
             allTextEnteredOnPage.Add(Server.HtmlEncode(((TextBox)control).Text));
          }
       }
       return allTextEnteredOnPage;
    }
