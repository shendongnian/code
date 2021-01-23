    public class TimedGate
    {
         private DateTime m_Last;
         private TimeSpan m_Gap;
         public TimedGate(TimeSpan gap)
         {
             m_Gap = gap;
         }
         public bool TryEnter()
         {            
             DateTime now = DateTime.UtcNow;
             return now.Subtract(m_Last) > m_Gap;
             {
                  m_LastEntered = now ;   
                  return true;                 
             }
             return false;  
         }
    }
