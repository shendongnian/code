    var myList = new[] {
        new { id = 1, price = 30},
        new { id = 2, price = 20},
        new { id = 3, price = 40},
        new { id = 3, price = 60},
        new { id = 1, price = 70},
        new { id = 1, price = 20},
        new { id = 2, price = 110},
        };
    var result = myList.GroupBy(x => x.id).Select(x => new { id = x.Key, price = x.Sum(y => y.price)});
