    ArrayList records = new ArrayList();
    for (...) {
      records.Add(new Record(){
        Name = Names[i].ToString(),
        Telephone = Phone[i].ToString(),
        Address = Address[i].ToString()
      });
    }
    ...
    Console.WriteLine(records[0].Address);
