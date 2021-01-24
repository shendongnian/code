    public class AlertRequest
    {
       private DateTime? m_FromDate = DateTime.MinValue;
       private DateTime? m_ToDate = DateTime.MaxValue;
    
       public DateTime? FromDate { 
         get {
           return m_FromDate;
         }
         set {
           m_FromDate = value ?? DateTime.MinValue;
         } 
       }
    
       public DateTime? ToDate { 
         get {
           return m_ToDate;
         }
         set {
           m_ToDate = value ?? DateTime.MaxValue;
         } 
       }
    }
