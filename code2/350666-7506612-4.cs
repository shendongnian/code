    public class HomeController : AsyncController
    {
        public void IndexAsync()
        {
            var client = new WebClient();
            AsyncManager.OutstandingOperations.Increment();
            client.DownloadStringCompleted += (s, e) => 
            {
                AsyncManager.OutstandingOperations.Decrement();
                if (e.Error != null)
                {
                    AsyncManager.Parameters["error"] = e.Error.Message;
                }
                else
                {
                    var serializer = new JavaScriptSerializer();
                    var model = serializer.Deserialize<FCC>(e.Result);
                    AsyncManager.Parameters["licenses"] = model.Licenses.License;
                }
            };
            client.DownloadStringAsync(new Uri("http://data.fcc.gov/api/license-view/basicSearch/getLicenses?searchValue=Verizon+Wireless&format=json"));
        }
        public ActionResult IndexCompleted(License[] licenses, string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                ModelState.AddModelError("licenses", error);
            }
            return View(licenses ?? Enumerable.Empty<License>());
        }
    }
