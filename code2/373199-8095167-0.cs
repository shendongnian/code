        Person oPerson1 = (from c in dt.AsEnumerable()
            select new Person
            {
                Name = c.Field<string>("Name"),
                HQ = c.Field<bool>("HQ")
            }).First(); //first person in a list
        Person oPerson2 = (from c in dt.AsEnumerable()
            select new Person
            {
                Name = c.Field<string>("Name"),
                HQ = c.Field<bool>("HQ")
            }).Skip(1).First(); //second person in a list
