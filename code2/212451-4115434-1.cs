      // ToDo: Create interface to populate the mymenutems
      List<string> mymenuitems = new List<string>();  // = someinterface
      mymenuitems.Add("Test Menu 1");
      mymenuitems.Add("Test Menu 2");
      mymenuitems.Add("Test Menu 3");
      mymenuitems.Add("Test Menu 4");
      foreach (var item in mymenuitems)
      { 
        var newtextbox = new TextBox();
        newtextbox.Text = item;
        CompanyStackPanel.Children.Add(newtextbox);        
      }
