    [Test]
    public void Test_weird_linq()
    {
        var names = new[]{ "Fred", "Roman" };
        var list = names.Select(x => new MyClass() { Name = x });
        list.First().Name = "Craig";
        Assert.AreEqual("Craig", list.First().Name);            
    }
    public class MyClass
    {
        public string Name { get; set; }
    }
