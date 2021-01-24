    List<MyClass> data = new List<MyClass>();
    MySqlDataReader rdr = cmd.ExecuteReader();
    while (rdr.Read())
    {
      var item = new MyClass();
      // here you will need to set the properties of item
      // to the various columns of your DB
      data.Add(item);
    }
    rdr.Close();
    // set the ItemsSource of your ListView
    temeList.ItemsSource = data;
