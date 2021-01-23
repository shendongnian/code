    using System.Linq;
    // ...
    string letters = "abcdefghij";
    int[] numbers = new [] { 1, 5, 2, 7 };
    string converted = new String(numbers.Select(n => letters[n - 1]).ToArray());
