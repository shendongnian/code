        public class SomeProgram
        {
            static void Main(string[] args)
            {
                Mock<IBlah> m = new Mock<IBlah>(MockBehavior.Strict);
                //I want to do the equivalent of this:
                //m.Setup(a => a.DoStuff(It.IsAny<string>())).Returns("mocked!");
                var method = typeof(IBlah).GetMethod("DoStuff", new Type[] { typeof(string) });
                MethodInfo genericIsAnyMethodInfo =
                    typeof(It).GetMethods().Single(e => e.Name == "IsAny").MakeGenericMethod(typeof(string));
                MethodCallExpression parameterForDoStuff = Expression.Call(genericIsAnyMethodInfo);
                //ParameterExpression parameterForDoStuff = Expression.Parameter(typeof(string), "x");
                ParameterExpression thisParameter = Expression.Parameter(typeof(IBlah), "someIBlahInstance");
                MethodCallExpression methodCall = Expression.Call(thisParameter, method, new[] { parameterForDoStuff });
                Expression<Func<IBlah, string>> lambdaExpression = Expression.Lambda<Func<IBlah, string>>(methodCall, thisParameter);
                //above line fails: Unhandled Exception: System.ArgumentException: ParameterExpression of type 'System.String' cannot be used for delegate parameter of type 'MoqTest.IBlah'
                m.Setup(lambdaExpression).Returns("mocked!");
                Assert.AreEqual("mocked!", m.Object.DoStuff(string.Empty));
            }
        }
