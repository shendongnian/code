    public interface IBase
    {
    }
    public interface IChild : IBase
    {
    }
    public class ChildClass : IChild
    {
        public ChildClass(IBase baseClass) {
            // Do what needs to be done
        }
    }
