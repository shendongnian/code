    public class MyCoolClass
    {
        public MyCoolClass(Func<string> getString)
        {
            m_getString = getString;
        }
        public MyCoolClass(string s)
        {
            m_string = s;
        }
        public string GetString()
        {
            return m_string ?? getString();
        }
        private string m_string;
        private Func<string> m_getString;
    }
