    public class Company
    {
        public string CompanyName { get; set; }
    }
    public class Blog
    {
        public string Name;
        public string URL;
        public Company MyCompany;
    }
    public class MyModel
    {
        public List<Blog> Blogs { get; set; }
    }
    public class Default1Controller : Controller
    {
     public class Company
    {
        public string CompanyName { get; set; }
    }
    public class Blog
    {
        public string Name;
        public string URL;
        public Company MyCompany;
    }
    public class MyModel
    {
        public List<Blog> Blogs { get; set; }
    }
    public class Default1Controller : Controller
    {
        List<Blog> topBlogs = new List<Blog>
          { 
              new Blog { Name = "ScottGu", URL = "http://weblogs.asp.net/scottgu/", MyCompany = new Company{
                  CompanyName = "Microsoft"
              }},
              new Blog { Name = "Scott Hanselman", URL = "http://www.hanselman.com/blog/", MyCompany = new Company{
                  CompanyName = "Microsoft"
              }},
              new Blog { Name = "Jon Galloway", URL = "http://www.asp.net/mvc", MyCompany = new Company{
                  CompanyName = "Microsoft"
              }}
          };
        //
        // GET: /Default1/
        public ActionResult Index()
        {
            var myModel = new MyModel();
            myModel.Blogs = topBlogs;
            
            return View(myModel);
        }
    }
