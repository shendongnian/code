    class Printable
    {
        protected readonly Action _action;
        public Printable(Action printAction)
        {
            _action = printAction;
        }
        public void Print()
        {
            _action();
        }
    }
    public Printer<T> where T : Printable
    {
        public Printer(T obj)
        {
            //etc...,
 
    var wrapper = new Printable( () => foo.Print() );
    var printer = new Printer<Printable>(wrapper);
