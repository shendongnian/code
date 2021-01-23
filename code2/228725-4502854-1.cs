    struct ImmutableValueType
    {
        private int _ID;
        private string _Name;
        public int ID
        {
            get { return _ID; }
        }
        public string Name
        {
            get { return _Name; }
        }
        // Infuser struct defined within the ImmutableValueType struct so that it has access to private fields
        public struct Infuser
        {
            private ImmutableValueType _Item;
            // write-only properties provide the complement to the read-only properties of the immutable value type
            public int ID
            {
                set { _Item._ID = value; }
            }
            public string Name
            {
                set { _Item._Name = value; }
            }
            public ImmutableValueType Produce()
            {
                return this._Item;
            }
            public void Reset(ImmutableValueType item)
            {
                this._Item = item;
            }
            public void Reset()
            {
                this._Item = new ImmutableValueType();
            }
            public static implicit operator ImmutableValueType(Infuser infuser)
            {
                return infuser.Produce();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // use of object initializer syntax made possible by the Infuser type
            var item = new ImmutableValueType.Infuser
            {
                ID = 123,
                Name = "ABC",
            }.Produce();
            Console.WriteLine("ID={0}, Name={1}", item.ID, item.Name);
        }
    }
