    public interface IMyClass<T>
        where T : IMyClass<T>
    {
        IEnumerable<T> Children { get; set; }
    }
    public class Foo : IMyClass<Foo> {
        public IEnumerable<Foo> Children {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
