    public class Login
    {
        public string Message;
        public string Name;
    
    
        public void Test()
        {
           Message =  "Welcome";  // changes field, same as this.Message = ...
           var Name = "Me";       // does not change field, hides field Name
        }
    
    }
