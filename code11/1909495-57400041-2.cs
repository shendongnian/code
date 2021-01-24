    public IList<Person> GetProducts(Category category)
    {
        var items = expressionClass.GetCategory(category);
        return items;
    }
    [TestMethod]
    public void Test2()
    {
        var expressionClass = Substitute.For<IExpresionClass>();
        var testClass = new TestClass(expressionClass);
        var category = new Category { flag = true, id = "55" };
        var list = testClass.GetProducts(category);
        expressionClass.Received().GetCategory(Arg.Is(category));
    }
