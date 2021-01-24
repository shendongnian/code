       public class dosomething
        {
        public Response somemethod()
            ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;  
            int counter = cache["userId"] as int;
            
            if (counter>=<<threshold>>) return;
            cache.Set("userId", counter +1, DateTimeOffset.Now.AddHours(1));   
            Response response = new Response(
                new Link("www.imawebservice.com/dosomething.svc/somemethod"))
            return response;
        }
    }
