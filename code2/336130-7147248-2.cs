    var enumerable = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    Console.WriteLine(String.Join(",",enumerable.ToArray()));
    var rangeSize = 2;
    var range = enumerable.Range(() => 5, rangeSize);
    Console.WriteLine(String.Join(",",range.ToArray())); // Output: 3,4,5,6,7
