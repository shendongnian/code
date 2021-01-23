    // MyClass.cs
    public partial class MyClass
    {
        int _id;
        public int ID { get { return _id; } set { _id = value; } }
        public MyClass(int identifier)
        {
            ID = identifier;
        }
    }
    // MyClass2.cs
    public partial class MyClass
    {
        public void ChangeID(int newID) 
        {
            _id = newID;
        }
    }
