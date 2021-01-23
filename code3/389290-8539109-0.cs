    var thing = new
    {
        red = other.Red,
        green = other.Green,
        blue = other.Blue,
    };    
    
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    string js = String.Format("var jsonObject= {0}; alert({0})", serializer.Serialize(thing));    
    Page.ClientScript.RegisterClientScriptBlock(thing.GetType(), "Thing", js , true);
