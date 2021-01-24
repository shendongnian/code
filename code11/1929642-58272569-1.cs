    var origOrder = MyExtensions.FuncX((Person p) => p.FirstName);
    var qOrig = new[]
    {
        new Person{ FirstName = "Elon", LastName = "Musk", ShoeSize = 44 },
        new Person{ FirstName = "Jeff", LastName = "Who?", ShoeSize = 40 }
    }
        .AsQueryable()
        .OrderBy(origOrder)
        .Select(p => p.LastName);
    var qChanged = qOrig.ChangeOrder(origOrder, x => x.ShoeSize); // <string, Person, string, int>
    var result = qChanged.ToList(); // "Who?", "Musk"
