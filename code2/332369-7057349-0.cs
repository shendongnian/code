    public class MyController : BaseController
    {
        public MyController(ISession session, IMail mail)
        {
             _session = session;
             _mail = mail; 
        }
    
       //other methods and member variables
    }
