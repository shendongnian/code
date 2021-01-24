    struct A
    {
        public int field1;
        public string field2;
        public A(string str)
        {
            this = new A(); // in structs 'this' is assignable
            field2 = str;
        }
    }
