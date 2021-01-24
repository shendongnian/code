       public class MsException : BaseException
            { 
            public MsException(int id)
            {
              var code = (Enum)errorId;
             StatusCode= code.ToString();
             Message =code.GetNames();
            }
            }
