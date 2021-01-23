    public class MyComponent
    {
        public MyComponent(IComponentContext context)
        {
            _context = context;
        }
        public void DoStuff()
        {
            var service = _context.Resolve(...);
        }
    }
