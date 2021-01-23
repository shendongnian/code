    public abstract class LinkedListBase<T>
        where T : LinkedListBase<T>
    {
        public T Next { get; set; }
        public T Previous { get; set; }
    }
    public class LinkedListImpl : LinkedListBase<LinkedListImpl>
    {
        public string Name { get; set; }
        // all of the value properties go here...
    }
