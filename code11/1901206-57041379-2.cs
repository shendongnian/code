    public class ExpresionClass : IExpresionClass
        {
            public IList<T> Get<T>(Expression<Func<T, bool>> predicate)
            {
                throw new NotImplementedException();
            }
    
        }
    public interface IExpresionClass
        {
            IList<T> Get<T>(Expression<Func<T, bool>> predicate);
        }
    public interface ITestClass
        {
            IList<Person> GetPerson();
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
    
            public IList<Person> GetPerson()
            {
                var test = expressionClass.Get<Person>(x => x.ParentType == "1AType" && x.OwnerUid == 5);
    
                return test;
            }
    
        }
    [TestMethod]
            public void Test1()
            {
                var person = new Person();
                person.OwnerUid = 59;
                person.ParentType = "ParentType";
    
                var expressionClass = Substitute.For<IExpresionClass>();
                expressionClass.Get(Arg.Is<Expression<Func<Person, bool>>>(expr => Lambda.Eq(expr, i => i.ParentType == "1AType" && i.OwnerUid == 5))).Returns(new List<Person> { person });
    
                var cut = new TestClass(expressionClass);
                var persons = cut.GetPerson();
    
                persons.First().ParentType.Should().Be("ParentType");
            }
