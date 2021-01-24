       var fn = Path.Combine(env.WebRootPath, "test.png");
    
       var contentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
    
       Response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
    
       return new PhysicalFileResult(fn, "image/jpeg");
