    class MyClass
    {
        private Guid _id;
        private string _personName;
        public MyClass(Guid id, string personName)
        {
            _id = id;
            _personName = personName;
        }
        public bool IsEqual(MyClass otherInstance)
        {
            return (_id == otherInstance._id && _personName == otherInstance._personName);
        }
    }
