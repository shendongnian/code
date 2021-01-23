            //Pull in the facebook app settings from the web.config file
            var settings = ConfigurationManager.GetSection("facebookSettings");
            var current = settings as IFacebookApplication;
            //Set up some stuff for later
            string currentFacebookPageID = current.AppId;
            bool currentFacebookPageLiked = false;
           //Get the signed request
           FacebookSignedRequest SignedRequest = FacebookSignedRequest.Parse(current, Request.Form["signed_request"]);
           dynamic SignedRequestData = SignedRequest.Data;
           //extract what we need from the request
           var RawRequestData = (IDictionary<string, object>)SignedRequestData;  
           
           //Check to see if we've got the data we need
           if (RawRequestData.ContainsKey("page") == true)
           {
               //We do, lets examine it and set the boolean as appropriate
               Facebook.JsonObject RawPageData = (Facebook.JsonObject)RawRequestData["page"];
               if (RawPageData.ContainsKey("id") == true)
                   currentFacebookPageID = (string)RawPageData["id"];
               if (RawPageData.ContainsKey("liked") == true)
                   currentFacebookPageLiked = (bool)RawPageData["liked"];
           }
           if (currentFacebookPageLiked)
           {
               //Do some stuff for fans
               lblName.Text = "Hi " + result.first_name + " - You are a fan";
           }
           else
           {
               //Do some stuff for non-fans
               lblName.Text = "Hi " + result.first_name + " - please click the like button";
           }
