    string searchString = txtSearch.Text.Trim();
    ArrayList arrayResult = new ArrayList();
    foreach(object obj in arrayList)
    {
       if(searchString == Convert.ToString(obj))
       {
          arrayResult.Add(obj);
       }
    }
    ListBox.DataSource = arrayResult;
