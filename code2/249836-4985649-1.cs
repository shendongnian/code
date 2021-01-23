    // use a struct to store your retrieved information
    public struct Details
    {
      DateTime date;
      Object data;
      
      public Details(DateTime Date, Object Data)
      {
        date = Date;
        data = Data;
      }
    }
    // use List<T> to define a dynamically-sized list
    List<Details> dataArray = new List<Details>();
    while (reader.Read()) // query the database
    {
      // add the information to the list as we iterate over it
      dataArray.Add(new Details(reader.GetDateTime("Date"),reader["Data"]));
    }
    // your new expansive array: dataArray.ToArray();
    // converting an object to datetime: Convert.ToDateTime();
