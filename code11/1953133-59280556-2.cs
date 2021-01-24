    var headers = context.HttpContext.Request.Headers;
         // Ensure that all of your properties are present in the current Request
         if(!String.IsNullOrEmpty(headers["version"])
         {
              // All of those properties are available, handle accordingly
              
              // You can redirect your user based on the following line of code
              context.Result = new RedirectResult(url);
         }
         else
         {
              // Those properties were not present in the header, redirect somewhere else
         }
