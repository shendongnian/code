    var tmp0 = (from c in dt.AsEnumerable()
      select new Person
      {
        Name = c.Field<string>("Name"),
        HQ = c.Field<bool>("HQ")
      });
    var tmp1 = tmp0.Take(1);
    var tmp2 = tmp1.Skip(2);
    List<Person> oPerson2 = tmp2.ToList();
