    public class BaseController : Controller {
        protected Meta Meta { get; set; }
        protected void Create()
        {
            if (Meta == null) { Meta = new Meta(); }
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
