    [TestClass]
    public class MoqExpressionTests {
        [TestMethod]
        public void Should_Build_Moq_Expression() {
            //Arrange
            //I want to do the equivalent of this:
            //m.Setup(a => a.DoStuff(It.IsAny<string>())).Returns("mocked!");
            var doStuff = typeof(IBlah).GetMethod("DoStuff", new Type[] { typeof(string) });
            var isAnyOfString = typeof(It).GetMethod("IsAny").MakeGenericMethod(typeof(string));
            // IBlah x =>
            ParameterExpression parameter = Expression.Parameter(typeof(IBlah), "x");
            // It.IsAny<string>()            
            var arg = Expression.Call(isAnyOfString);
            // IBlah x => x.DoStuff(It.IsAny<string>())           
            MethodCallExpression body = Expression.Call(parameter, doStuff, new[] { arg });
            //Func<IBlah, string> = IBlah x => x.DoStuff(It.IsAny<string>())
            Expression<Func<IBlah, string>> expression = 
                Expression.Lambda<Func<IBlah, string>>(body, parameter);
            var expected = "mocked!";
            Mock<IBlah> m = new Mock<IBlah>(MockBehavior.Strict);
            m.Setup(expression).Returns(expected);
            var subject = m.Object;
            //Act
            var actual = subject.DoStuff(string.Empty);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        public interface IBlah {
            string DoStuff(string x);
        }
    }
