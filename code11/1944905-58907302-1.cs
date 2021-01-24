    public Printer<T> where T : Printable
    {
        public Printer(T obj)
        {
            //etc...,
 
    var wrapper = new Printable( () => foo.Print() );
    var printer = new Printer<Printable>(wrapper);
