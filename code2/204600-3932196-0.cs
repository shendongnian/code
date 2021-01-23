    class Callee
    {
        public void SetX(TypeOfCaller caller, int value)
        {
        }
    }
    class TypeOfCaller
    {
        public void Do()
        {
            Callee instance;
            //..
            instance.SetX(this, 5);
        }
    }
