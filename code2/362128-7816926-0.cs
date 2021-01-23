      List<string> dataTags = ...; //get list of attributes to use from xml 
      foreach (string d in dataTags)
      {
             DataGridTextColumn col = new DataGridTextColumn();
             col.Binding = new Binding() { XPath = "@" + d } ;
             col.Header = d;
             dataGrid.Columns.Add(col);
      } 
