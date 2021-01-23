    public class BaseController : Controller { 
       public void Create(string a) { 
          var a = new Meta(); 
       } 
    }
    
    public class ABC : BaseController { 
       public void Create(string a, string b) { 
          base.Create(a);
       } 
    } 
     
    public class DEF : BaseController { 
       public void Create(string a, string b, string c) { 
          base.Create(a);
       } 
    } 
