    public class RecursionTest
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public RecursionTest Test { get; set; }
        public RecursionTest ParentTest { get; set; }
    }
    var rec1 = new RecursionTest
    {
        IntValue = 20,
        StringValue = Guid.NewGuid().ToString()
    };
    rec1.Test = new RecursionTest
    {
        IntValue = 30,
        StringValue = Guid.NewGuid().ToString(),
        ParentTest = rec1
    };
    rec1.Test.Test = new RecursionTest
    {
        IntValue = 40,
        StringValue = Guid.NewGuid().ToString(),
        ParentTest = rec1.Test
    };
    foreach (var bot in GetAllProperties(rec1, PropertyRecursionOverflowProtectionType.SkipSameReference))
    {
        Console.WriteLine($"{new string(' ', bot.Level * 2)}{bot.PropertyInfo.Name}: {bot.CurrentObject}");
    }
