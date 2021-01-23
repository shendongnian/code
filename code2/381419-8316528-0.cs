    public class Node<T>
    {
        T m_oValue = null;
        public T Value
        {
            get { return m_oValue; }
            set
            {
                if (m_oValue == null)
                {
                    m_oValue = value;
                }
            }
        }
    }
