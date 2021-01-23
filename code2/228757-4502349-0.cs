    class Test<T>
    {
        public T Val;
        public void Do(T val)
        {
            Val = val;
            dynamic dynVal = Val;
            MainClass.Print(dynVal);
        }
    }
