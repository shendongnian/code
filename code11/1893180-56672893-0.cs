    var inventory = Enumerable.Repeat(10, 1000)
    .Concat(Enumerable.Repeat(15, 500))
    .Concat(Enumerable.Repeat(20, 2000));
    var avg1 = inverntory.Take(100).Average(); // 10
    var avg2 = inverntory.Take(1200).Average(); // 10.8333333333333
