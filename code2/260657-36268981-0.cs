    namespace Tests
    {
       [TestClass()]
       public class MyTests
       {
          [ClassInitialize()]
          public static void Init(TestContext context)
          {
            // mock up HTTP request
            var sb = new StringBuilder();
            TextWriter w = new StringWriter(sb);
            var httpcontext = new HttpContext(new HttpRequest("", "http://www.example.com", ""), new HttpResponse(w));
            HttpContext.Current = httpcontext;
          }
          [TestMethod()]
          public void webSerivceTest()
          {
            // the httpcontext will be already set for your tests :)
          }
       }
    }
  
