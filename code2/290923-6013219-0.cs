    public class Context
    {
        [ThreadStatic()]
        private static Context _Context = null;
        private HttpContext _HttpContext = null;
        public Context()
        {
            _HttpContext = HttpContext.Current;
        }
    
        public static Context Current
        {
            if(_Context == null || 
               _HttpContext != _HttpContext.Current)
            {
                _Context = new Context();
            }
            return _Context;
        }
    }
