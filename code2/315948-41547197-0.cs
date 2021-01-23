     var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
     var json = serializer.Serialize(user);
    controller.Response.SetCookie(
            new HttpCookie({string_name}, json)
            {
                Expires = false // use this when you want to delete
                        ? DateTime.Now.AddMonths(-1)
                        : DateTime.Now.Add({expiration})
            });
