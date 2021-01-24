    public class Address
    {
       private string[] m_address = new string[2];
    
       public string this[int index]
       {
          get => index >= 0 && index < m_address.Length ? m_address[index] : null;
          set
          { 
              if (index >= 0 && m_address.Length > index)
              {
                  m_address[index] = value;
              }
          }
       }
    }
