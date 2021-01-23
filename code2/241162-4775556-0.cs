    class B
    {
        private A a;
        public event EventHandler Print
        {
            add { a.Print += value; }
            remove { a.Print -= value; }
        }
    }
