    public class HomeController : AsyncController
    {
        public void IndexAsync()
        {
            var uri = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20flickr.photos.recent";
            var httpClient = new HttpClient(uri);
    
            AsyncManager.OutstandingOperations.Increment();
            httpClient.GetAsync("").ContinueWith(r =>
                {
                    var xml = XElement.Load(r.Result.Content.ContentReadStream);
    
                    var owners = from el in xml.Descendants("photo")
                                    select (string)el.Attribute("owner");
    
                    AsyncManager.Parameters["owners"] = owners;
                    AsyncManager.OutstandingOperations.Decrement();
                });
        }
    
        public ActionResult IndexCompleted(IEnumerable<string> owners)
        {
            return View(owners);
        }
    }
