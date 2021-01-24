     void Application_BeginRequest(object sender, EventArgs e)
        {
           var u = Request.ServerVariables("HTTP_USER_AGENT");
           var uri =  Request.Url.AbsoluteUri.ToLower();
              //put DetectMobileBrowsersCode Here, for exmaple if user agents contains apple , android , etc ...
        
              if (b.IsMatch(u) || v.IsMatch(Left(u, 4)))
              {
                  Response.Redirect("http://m.yoursite.com");
              } 
        }
