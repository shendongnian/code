    public Class1
    {
        private Class2 myClass2;
    
        public Class1()
        {
            myClass2 = new Class2();
        }
    
        public SomeObject anObject
        {
            get { return myClass2.MyObject; }
            set { myClass2.MyObject = value; }
        }
    }
