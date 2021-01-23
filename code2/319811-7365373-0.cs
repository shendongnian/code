    dg.ItemsSource.Add(data);
    dg.SelectedItem = data;                  //set SelectedItem to the new object
    dg.ScrollIntoView(data, dg.Columns[0]);  //scroll row into view, for long lists, setting it to start with the first column
    dg.Focus();                              //required in my case because contextmenu click was not setting focus back to datagrid
    dg.BeginEdit();                          //this starts the edit, this works because we set SelectedItem above
