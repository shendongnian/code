            var sb = new StringBuilder();
            TextWriter w = new StringWriter(sb);
            var context = new HttpContext(new HttpRequest("", "http://www.example.com", ""), new HttpResponse(w));
            HttpContext.Current = context;
            Console.WriteLine(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
