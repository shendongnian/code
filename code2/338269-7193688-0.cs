    public class Student {
      public string m_firstName;
      public string m_lastName;
    
      public string FullName {
        get { return String.Format("{0} {1}", m_firstName, m_lastName); }
      }
    }
