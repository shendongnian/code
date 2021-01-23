    class MyMdiContainer : Form
    {
        private object m_var;
        
        // Property approach
        public object MyVar
        {
            get { return m_var; }
            set { m_var = value; }
        }
    }
