     public ActionResult DisplayInfo()
            {
                string request = Request.QueryString["myInfo"];
    
                MapInfoViewModel info = new MapInfoViewModel()
                {
                    Place = request
                };
                return new ContentResult
                {
    
                    Content = JsonConvert.SerializeObject(info),
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
