    class x
    {
        public void a()
        {
            CommonMethod();
            // a exclusive code
        }
        public void b()
        {
            CommonMethod();
            
            // b exclusive code
        }
        private void CommonMethod()
        {
            // common code
        }
    }
