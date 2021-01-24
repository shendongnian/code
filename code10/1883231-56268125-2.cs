    using System;
    using System.IO;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    
    namespace WebApplication2.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                string strurlTest = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
                WebRequest requestObjGet = WebRequest.Create(strurlTest);
                HttpWebResponse responseObjGet = null;
    
                responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();
    
                string strresulttest = null;
                JavaScriptSerializer js = new JavaScriptSerializer();
    
                using (Stream stream = responseObjGet.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strresulttest = sr.ReadToEnd();
                    Test[] tests = new JavaScriptSerializer().Deserialize<Test[]>(strresulttest);
                }
    
                return View();
            }
        }
    
        public class Test
        {
            public int postId { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string body { get; set; }
        }
    }
