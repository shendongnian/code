    // you need a class to hold all of the columns in a row
    class MyData {
      public string ColumnOne { get; set; }
      public string ColumnTwo { get; set; }
      public string ColumnThree { get; set; }
      public string ColumnFour { get; set; }
    }
    // list to hold instances of the class created above
    var list = new List<MyData>
    /* code to connect and open reader */
    while(reader.Read()) {
      // store your row
      var data = new MyData {
        ColumnOne = reader.GetString(0),
        ColumnTwo = reader.GetString(1),
        ColumnThree = reader.GetString(2),
        ColumnFour = reader.GetString(3),
      };
      // add it to the list
      list.Add(data);
    }
    // you can loop through the list using a foreach loop
    foreach(var row in list) {
      Console.WriteLine("Start Here");
      Console.WriteLine(row.ColumnOne);
      Console.WriteLine(row.ColumnTwo);
      Console.WriteLine(row.ColumnThree);
      Console.WriteLine(row.ColumnFour);
      Console.WriteLine(); // you don't need to pass in an empty string
    }
