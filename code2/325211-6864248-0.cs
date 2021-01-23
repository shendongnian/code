    List<PersonInfo> persons = new List<personInfo>();
    using (StreamReader sr = new StreamReader(filename))
    {
       while (!sr.EndOfStream)
       {
          string line = sr.ReadLine();
          string[] fields = line.Split(new char[] { '|' });
          PersonInfo p = new PersonInfo
          {
             Name = fields[0],
             Age = int.Parse(fields[1]),
             DateOfBirth = DateTime.Parse(fields[2]),
             NetWorth = decimal.Parse(fields[3])
          });
          Debug.WriteLine(string.Format("Name={0}, Age={1}, DateOfBirth={2}, NetWorth={3}",
             p.Name, p.Age, p.DateOfBirth, p.NetWorth);
          persons.Add(p);
       }
    }
    AddResource("Persons", persons);
