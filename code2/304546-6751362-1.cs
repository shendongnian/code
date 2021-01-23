        protected bool IsPageLiked()
        {
            var current = ConfigurationManager.GetSection("facebookSettings") 
                          as IFacebookApplication;
            dynamic signedRequest = FacebookSignedRequest.Parse(current, Request);
            try
            {
                return signedRequest.Data.page.liked;
            }
            catch (Exception)
            {
                return false;
            }       
        }
