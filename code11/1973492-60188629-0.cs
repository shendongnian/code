    public class AlertRequest
    {
       private DateTime? m_FromDate;
       private DateTime? m_ToDate;
    
       public DateTime? FromDate { 
         get {
           return m_FromDate;
         }
         set {
           m_FromDate = value ?? DateTime.MinValue;
         } 
       }
    
       public DateTime? FromDate { 
         get {
           return m_ToDate;
         }
         set {
           m_ToDate = value ?? DateTime.MaxValue;
         } 
       }
    }
