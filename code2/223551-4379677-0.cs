        public int Value
        {
            get { return m_value; }
            set { 
                m_value = value;
                if(ValueChanged != null)
                {
                   ValueChanged();
                }
            }
        }
