    public class Geek
    {
           private string[] m_address = new string[2];
           public string this[int index]
           {
              get { 
                  if (index >= 0 && index < index.length)
                  {
                      return m_address;
                  }
                  else
                  {
                      return null;
                  }
              }
              set { 
                  if (index >= 0 && index < index.length)
                  {
                      m_address = value;
                  }
              }
           }
    }
