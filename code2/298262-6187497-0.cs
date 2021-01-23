    class Container : IInterfaceA, IInterfaceB
    {
        private object _obj;
        public Container(object obj)
        {
            // Check that the object really implements those two interfaces.
            _obj = obj;
        }
        void IInterfaceA.Method1()
        {
            ((IInterfaceA)_obj).Method1();
        }
        // And so on for all methods of the interfaces.
    } 
