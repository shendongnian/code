    List<TestClass> tests = new List<TestClass>(){
                new TestClass() { FirstProp = 1, SecondProp = new TestClass() { SecondProp = new TestClass() } },
                new TestClass() { FirstProp = 2 },
                new TestClass() { FirstProp = 3, SecondProp = new TestClass() },
                new TestClass() { FirstProp = 4 },
            };
            var variable = Expression.Parameter(typeof(TestClass), "x");
            var nullSafe = variable.ElvisOperator("SecondProp").ElvisOperator("SecondProp");
            var cond = Expression.NotEqual(nullSafe, Expression.Constant(null, variable.Type));
            var lambda = Expression.Lambda<Func<TestClass, bool>>(cond, new ParameterExpression[] { variable });
            tests = tests.AsQueryable().Where(lambda).ToList();
            Console.WriteLine(tests.Count);
