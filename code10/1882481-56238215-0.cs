    public class MsException : BaseException
       { 
       public MsException(int id)
          {
             var code = (Enum)errorId;
    
             this.StatusCode= code.ToString();
             this.Message =code.GetNames();
          }
       }
