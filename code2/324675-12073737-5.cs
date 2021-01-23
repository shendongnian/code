    class Foo
    {
        private readonly string _field;
        public Foo()
        {
            _field = GetField();
        }
        private string GetField()
        {
            return "MyFieldInitialization";
        }
    }
