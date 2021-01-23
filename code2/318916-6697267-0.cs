    class MyClass
    {
        private string m_Name;
        private int m_SomeValue;
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (value != m_Name)
                {
                    m_Name = value;
                    m_SomeValue++;
                    // Raise Event
                }
            }
        }
        public int SomeValue
        {
            get { return m_SomeValue; }
            set
            {
                if (m_SomeValue != value)
                {
                    m_SomeValue = value;
                    // Raise Event
                }
            }
        }
        
