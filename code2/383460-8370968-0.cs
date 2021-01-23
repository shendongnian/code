    while(reader.Read()) 
    {
      var value1 = reader.GetValue(0); // On first iteration will be hello
      var value2 = reader.GetValue(1); // On first iteration will be hello2
      var value3 = reader.GetValue(2); // On first iteration will be hello3
    }
