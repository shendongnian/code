    using System;
    using System.IO;
    using System.Web;
    using System.Web.SessionState;
    class Program
    {
        static void Main()
        {
            var request = new HttpRequest("", "http://localhost", "");
            var response = new HttpResponse(TextWriter.Null);
            var context = new HttpContext(request, response);
            var id = new SessionIDManager().CreateSessionID(context);
            Console.WriteLine(id);
        }
    }
