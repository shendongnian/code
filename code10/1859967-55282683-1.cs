    public ActionResult Insert(dynamic[] dynamicClass)
        {
            try
            {
                //do something...
   
    var movie = //convert dynamicClass to whatever you want...  ;
                 return View(movie);
            }
            catch (Exception ex)
            {
                // Otherwise return a 400 (Bad Request) error response
                return BadRequest(ex.ToString());
            }
        }
