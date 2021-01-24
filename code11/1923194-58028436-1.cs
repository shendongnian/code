    public class SystemUnderTest {
        public SystemUnderTest() {
        }
        public IDependency Dependency { get; set; }
        public string DoWork() {
            return this.Dependency.GetValue();
        }
    }
    public interface IDependency {
        string GetValue();
    }
