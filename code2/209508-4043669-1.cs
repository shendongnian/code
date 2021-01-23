    struct TwoBits
    {
        int m_data;
        public int Data
        {
            set
            {
                m_data = 0x03 & value;
            }
            get
            {
                return m_data;
            }
        }
    }
