         public string postFormData(Uri formActionUrl, string postData)
         {
            //Make a HttpWebReguest first 
    
            //set cookiecontainer
    
            gRequest.CookieContainer = new CookieContainer();// gCookiesContainer;
          
            //Manage cookies
           
            #region CookieManagement
            if (this.gCookies != null && this.gCookies.Count > 0)
            {
                
                gRequest.CookieContainer.Add(gCookies);
            }
           
            try
            {
               
               //logic to postdata to the form
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              
            }
            //post data logic ends
            //Get Response for this request url
            try
            {
                gResponse = (HttpWebResponse)gRequest.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
              
            }
            //check if the status code is ok
          
                if (gResponse.StatusCode == HttpStatusCode.OK)
                {
                    //get all the cookies from the current request and add them to the response object cookies
                    
                    gResponse.Cookies = gRequest.CookieContainer.GetCookies(gRequest.RequestUri);
                    //check if response object has any cookies or not
                 
                                       
                    if (gResponse.Cookies.Count > 0)
                    {
                        //check if this is the first request/response, if this is the response of first request gCookies
                        //will be null
                        if (this.gCookies == null)
                        {
                            gCookies = gResponse.Cookies;
                        }
                        else
                        {
                            foreach (Cookie oRespCookie in gResponse.Cookies)
                            {
                                bool bMatch = false;
                                foreach (Cookie oReqCookie in this.gCookies)
                                {
                                    if (oReqCookie.Name == oRespCookie.Name)
                                    {
                                        oReqCookie.Value = oRespCookie.Value;
                                        bMatch = true;
                                        break; 
                                    }
                                }
                                if (!bMatch)
                                    this.gCookies.Add(oRespCookie);
                            }
                        }
                    }
            #endregion
                    StreamReader reader = new StreamReader(gResponse.GetResponseStream());
                    string responseString = reader.ReadToEnd();
                    reader.Close();
                    return responseString;
                }
                else
                {
                    return "Error in posting data";
                } 
            
        }
