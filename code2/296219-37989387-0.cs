    // This class add just an Owner (parent) to the list
    public class OwnedList<T> : List<T>
    {
        public Object Owner { set; get; }
        public OwnedList(Object owner)
        {
            Owner = owner;
        }
    }
