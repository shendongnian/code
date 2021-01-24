    public class ExpresionClass : IExpresionClass
    {
        T[] IExpresionClass.Get<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
    public interface IExpresionClass
    {
        T[] Get<T>(Expression<Func<T, bool>> predicate = null);
    }
    public interface ITestClass
    {
        Person[] GetPerson();
    }
    public class Person
        {
            public string ParentType { get; set; }
    
            public int OwnerUid { get; set; }
        }
    public class TestClass : ITestClass
    {
        private readonly IExpresionClass expressionClass;
        public TestClass(IExpresionClass expressionClass)
        {
            this.expressionClass = expressionClass;
        }
        public Person[] GetPerson()
        {
            var test = expressionClass.Get<Person>(x => x.ParentType == "1AType" && x.OwnerUid == 10);
            return test;
        }
    }
    [TestMethod]
        public void DoesLinqMatch()
        {
            var person = new Person();
            person.OwnerUid = 59;
            person.ParentType = "ParentType";
            Person[] personsarray = new Person[] { person };
            var expressionClass = Substitute.For<IExpresionClass>();
            expressionClass.Get(Arg.Is<Expression<Func<Person, bool>>>(expr => Lambda.Eq(expr, i => i.ParentType == "1AType" && i.OwnerUid == 10))).Returns(personsarray);
            var cut = new TestClass(expressionClass);
            var persons = cut.GetPerson();
            persons.First().ParentType.Should().Be("ParentType");
        }
