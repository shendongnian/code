    public class ReferenceProperty<T>
    {
        private T[] typeReference;
        public ReferenceProperty(T value)
        {
            typeReference = new T[] { value };
        }
        public T PropertyAsValue
        {
            get { return typeReference[0]; }
            set { typeReference[0] = value; }
        }
        public T[] PropertyAsReference
        {
            get { return typeReference; }
        }
    }
