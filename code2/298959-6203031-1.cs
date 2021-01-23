    class ModifiedClosure
    {
        private Action<Customer1, Customer2> _baseMap;
        public ModifiedClosure(Action<Customer1, Customer2> baseMap)
        {
            _baseMap = baseMap;
        }
    
        public void Method(SpecialCustomer1 c1, SpecialCustomer2 c2)
        {
            _baseMap(c1, c2);
            c2.SpecialProperty = c1.SpecialProperty;
        }
    }
