    public class Friend
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    ...
    public ActionResult About()
    {
        var app = new FacebookApp();
        var result = (JsonObject)app.Get("me/friends"));
        var model = new List<Friend>();
        foreach( var friend in (JsonArray)result["data"])
            model.Add( new Friend()
            {
                Id = (string)(((JsonObject)friend)["id"]),
                Name = (string)(((JsonObject)friend)["name"])
            };
        
        return View(model);
    }
