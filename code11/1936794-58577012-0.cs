    using System.Linq;
    var source = new List<int> { 0, 0, 0, 27, 29, 24, 35, 33, 32, 1, 1, 1,
        22, 55, 44, 44, 55, 59, 0, 0, 0, 0 };
    var result = source
        .SkipWhile(n => n == 0) // Leading 0s ignored
        .GroupConsecutiveByKey(n => n / 10) // Next items having same tens grouped
        .Where(g => !g.Any(n => n % 2 == 0)) // Group containing an even number ignored
        .Skip(1) // Next group ignored
        .Where(g => !g.All(n => n == 1)) // 1s are ignored as well
        .LastOrDefault(g => g.Any(n => n % 10 == 9)) // Contains item ending in 9 from end
        .FirstOrDefault(n => n % 10 == 9); // Item ending in 9
    Console.WriteLine($"Result: {result}");
