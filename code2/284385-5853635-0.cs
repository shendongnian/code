    class Class1
    {
        public void Function1()
        {
        }
    }
    class Class2
    {
        private Class1 obj;
        public void Function2()
        {
            obj.Function1();
        }
    }
