      // ToDo: Create interface to populate the mymenutems
      List<string> mymenuitems = new List<string>();  // = someinterface
      mymenuitems.Add("Test Menu 1");
      mymenuitems.Add("Test Menu 2");
      mymenuitems.Add("Test Menu 3");
      mymenuitems.Add("Test Menu 4");
      foreach (var item in mymenuitems)
      { 
        var margins = new Thickness(2);
        var newtextbox = new Label() { Margin = margins, Content = item};
        MenuItem_Company.Items.Add(newtextbox);      
      }
