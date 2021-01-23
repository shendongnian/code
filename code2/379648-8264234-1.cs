    public class BaseController : Controller { 
       protected Meta meta;
       public void Create() { 
          var meta = new Meta(); 
       } 
    }
    
    public class ABC : BaseController { 
       public void Create(string a, string b) { 
          base.Create();
       } 
    } 
     
    public class DEF : BaseController { 
       public void Create(string a, string b, string c) { 
          base.Create();
       } 
    } 
