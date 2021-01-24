    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using SomeApp.Models;
     
    public class HtmlResult : IHttpActionResult
    {
        private User model;
     
        public HtmlResult(User model)
        {
            this.model = model;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            string user = "<html><head><meta charset=utf-8 /></head></body>" +
                "<h2>" + user.Name + "</h2><h3>" + user.Login + "</h3><h3>"
                + user.Bday+ "</h3>" + "</body></html>";
            
            var tmp = new HttpResponseMessage();
            tmp.Content = new StringContent(user);
            tmp.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
     
            return Task.FromResult(tmp);
        }
    }
