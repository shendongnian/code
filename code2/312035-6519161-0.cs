        class ExceptionHandler 
        { 
            public T Process(Func<T> func()) 
            {
               try { return func(); }
               catch(Exception ex) { // Do stuff }
            }
            public void Process(Action a) 
            { 
                try { action() }
                catch(Exception ex) { // Do stuff }
            }
        }
 
