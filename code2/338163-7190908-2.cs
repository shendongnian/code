    public class MyComponent
    {
        IComponentContext _context;
        public MyComponent(IComponentContext context)
        {
            _context = context;
        }
        public void DoStuff()
        {
            var service = _context.Resolve(...);
        }
    }
