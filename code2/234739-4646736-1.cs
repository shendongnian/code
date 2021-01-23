    public class Foo
    {
        public Bar Bar { get; set; }
    }
    public class Bar
    {
        public string Fizz { get; set; }
    }
    private Expression<Func<Bar, bool>> BarExp()
    {
        return b => b.Fizz == "fizz";
    }
    private Expression<Func<Foo, bool>> BarToFoo(Expression<Func<Bar, bool>> barExp)
    {
        Expression<Func<Foo, bool>> result =
            foo => barExp.Compile().Invoke(foo.Bar);
        return result;
    }
    [Test]
    public void TestBarToFoo()
    {
        var fooInstance = new Foo { Bar = new Bar() { Fizz = "fizz" } };
        var barExpr = this.BarExp();
        Console.WriteLine(
            barExpr.Compile().Invoke(fooInstance.Bar)); // = True
        Console.WriteLine(
            this.BarToFoo(barExpr).Compile().Invoke(fooInstance)); // = True
    }
