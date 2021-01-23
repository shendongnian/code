    public static class StaticClass {
        public void ClearSession() {
            TheContext["VariableName"] = null;
        }
        public static HttpContextBase TheContext{
            get { 
                if (_context == null)
                    _context = new HttpContextWrapper(HttpContext.Current);
                return _context; }
            set { _context = value; }
        }
    }
