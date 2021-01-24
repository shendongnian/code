    IList<Order> orderlist = new List<Order>() {
        new Order () { Name = "James", UserIDFK = "1", Authorized = false},
            new Order () { Name = "James", UserIDFK = "1", Authorized = true},
            new Order () { Name = "Ryan", UserIDFK = "2", Authorized = false},
            new Order () { Name = "Pete", UserIDFK = "3", Authorized =  false},
            new Order () { Name = "Pete", UserIDFK = "3", Authorized =  false},
            };
    var result = orderlist
        .GroupBy(o => o.UserIDFK)
        .Where(g => g.All(x => !x.Authorized)) // will exclude James
        .Select(g => g.First());
