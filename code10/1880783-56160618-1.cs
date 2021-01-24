    public interface IProtectedMethod {
        bool ProtectedMethod();
    }
    public class AA {
        private readonly IProtectedMethod x;
        public AA(IProtectedMethod x) {
            this.x = x;
        }
        public bool PublicMethod() {
            return x.ProtectedMethod();
        }
    }
    public class AATest {
        [Fact]
        public void TestUsingStrategySub() {
            var x = Substitute.For<IProtectedMethod>();
            var anA = new AA(x);
            anA.PublicMethod();
            x.Received().ProtectedMethod();                
        }
    }
