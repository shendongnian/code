    public class TransientDependencyWrapper : IDependency
    {
        public void DoSomething()
        {
            new MyStatefulDependency().DoSomething();
        }
    }
