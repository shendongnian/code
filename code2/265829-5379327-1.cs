    public class OtherClass<T> where T : IBaseline
    {
        public T GenericInstance { get; private set;}
        public OtherClass(T genericInstance)
        {
            this.GenericInstance = genericInstance;
        }
    }
