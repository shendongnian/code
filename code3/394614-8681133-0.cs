    namespace Foo
    {
        public class A
        {
            // note the change to the signature
            public string B(IEnumerable<IWork> workToDo)
            {
                return workToDo.ToString();
            }
    
            static void Main()
            {
                var type = Type.GetType("Foo.A");
                var info = type.GetMethod("B");
                var list = new List<Work>();
                var x = info.Invoke(Activator.CreateInstance(type), new [] { list });
            }
        }
    
        public interface IWork { }
        public class Work : IWork { }
    }
