 public class ExceptionClass: Exception   
{
        public ExceptionClass()
        {
        }
        public ExceptionClass(List<string> names) :base(String.Format("String with ID :{0} not found", string.Join(", ", names.Select(sns => sns.SerialNumber.ToString()))))
        {
        }
    }
