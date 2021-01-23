        string m_Text;
        public string Text
        {
            get
            {
                return m_Text;
            }
            set
            {
                m_Text = value;
                if (m_TextLength == 0)
                {
                    m_TextLength = value.Length;
                }
            }
        }
        private int m_TextLength;
        public int TextLength
        {
            get
            {
                return m_TextLength;
            }
        }
