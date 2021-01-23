    enum RealEnum : uint
    {
        SomeValue = 0xDEADBEEF,
    }
    static class FakeEnum
    {
        public const uint SomeValue = 0xDEADBEEF;
    }
    var x = RealEnum.SomeValue;
    var y = FakeEnum.SomeValue;
    // what's the value?
    var xstr = x.ToString(); // SomeValue
    var ystr = y.ToString(); // 3735928559
