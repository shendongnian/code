    struct A
    {
        public int field1;
        public string field2;
        public A(string str)
        {
            this = default(A); // in structs 'this' is assignable
            field2 = str;
        }
    }
