    // make a list we can use
    List<Object[]> details = new List<Object[]>();
    // populate the data
    using (SqlConnection connection = new SqlConnection("<connection string>"))
    {
        SqlCommand command = new SqlCommand("<query string>");
        SqlReader reader = command.ExecuteReader();
        .. go through the database
        while (reader.Read())
        {
          DateTime date = reader.GetDateTime("Date");
          Double data = reader.GetDouble("Data");
          // convert the datetime to unix time
          // http://www.epochconverter.com/
          var epoc = (date.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
          details.Add(new Object[]{ epoc, data });
        }
    }
    // Now we serialize
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    String result = serializer.Serialize(details.ToArray());
