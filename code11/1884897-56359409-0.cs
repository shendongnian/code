                              List<Log> logs = new List<Log>();
                      XmlReader reader = XmlReader.Create(@"C:\Logs\Workflow User 
                              Functions\2019\03\05\13.xml");
                      reader.MoveToContent();
                         while (reader.Read())
          {
	      if (reader.HasAttributes)
	      {
		  var lg = new Log
		  {
			date = reader.GetAttribute("date"),
			datetime = reader.GetAttribute("datetime")
		  };
		logs.Add(lg);
		Console.WriteLine($"{lg.date} {lg.datetime}");
	}
}
            Console.ReadLine();
