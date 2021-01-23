    public class postcontroller : basecontroller
    {                      
            public ActionResult wall()
            {
                var client = new FacebookClient( Session['fb_access_token'] as string);
                var args = new Dictionary<string, object>();
                args["message"] = "Klaatu Verata N......(caugh, caugh)";
                
                try
                {
                    client.Post("/me/feed", args); // post to users wall (feed)
                    client.Post("/{page-id}/feed", args); // post to page feed
                }
                catch (Exception ex)
                {
                    // Log if anything goes wrong 
                }
    
            }
    }
