    public class Geek
    {
        private string[] m_address = new string[2];
    
        public void setAddress(int index, string valueM)
        {
            if (index >= 0 && index < m_address.Length)
            {
                m_address[index] = valueM;
            }
        }
    
        public string getAddress(int index)
        {
            if (index >= 0 && index < m_address.Length)
            {
                return m_address[index];
            }
            else
            {
                return null;
            }
        }
    }
