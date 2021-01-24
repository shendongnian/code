    public class TestClass
        {
            public int FirstProp { get; set; }
    
            public TestClass SecondProp { get; set; } 
        }
    var variable = Expression.Parameter(typeof(TestClass), "x");
    var nullSafe = variable.ElvisOperator("SecondProp");
