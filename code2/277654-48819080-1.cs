    interface IUser
    {
        string EMail { get; }       // immutable, so get only an no set
        string Language { get; }
    }
    public class DummyUser : IUser
    {
        public DummyUser(string email, string language)
        {
            m_email = email;
            m_language = language;
        }
        private string m_email;
        public string EMail
        {
            get { return m_email; }
        }
        private string m_language;
        public string Language
        {
            get { return m_language; }
        }
    }
    public class SmartyUser : IUser
    {
        public SmartyUser(string email, string language, string occupation)
        {
            m_email = email;
            m_language = language;
            m_occupation = occupation;
        }
        private string m_email;
        public string EMail
        {
            get { return m_email; }
        }
        private string m_language;
        public string Language
        {
            get { return m_language; }
        }
        private string m_occupation;
    }
