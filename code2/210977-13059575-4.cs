        public class Test
        {
            // some member functions to invoke
            public int EventHandler1(string param1, int param2) { return 1; }
            public int EventHandler2(string param1, int param2) { return 2; }
            // Declaration for a (closed) delegate for the member functions
            private delegate int EventHandler(string param1, int param2);
            // Syntactic sugar for declaring the table 
            private class EventDispatchTable : DispatchTable<string, Test, EventHandler> { };
            
            // Declare dispatch table and initialize 
            static EventDispatchTable dispatchTable = new EventDispatchTable
            {
                { "Event1", c => c.EventHandler1 }
                ,{ "Event2", c => c.EventHandler2 }
            };
            // Invoke via the dispatch table
            public int DoDispatch(string eventName, string param1, int param2)
            {
                return dispatchTable.GetDelegate(this, eventName)(param1, param2);
            }
        }
