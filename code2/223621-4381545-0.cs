    string someString = "1,2,3,4,5,6,7";
    var numbers = someString.Split(',')
                             .Select(s => Int32.Parse(s));
    int[] firstFive = numbers.Take(5).ToArray();
    int[] afterFirstFive = numbers.Skip(5).ToArray();
