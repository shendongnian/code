    var col = new[] { 1, 6, 4, 8, 3, 5, 1, 7 };
    var res1 = col.MoreThan(2, c => c == 1); //false
    var res2 = col.MoreThan(1, c => c == 1); //true
    var res3 = col.LessThan(4, c => c > 5); //true
    var res4 = col.LessThan(3, c => c > 5); //false
