    public void ShowFriendList(string at, string id)
    {
        //var fb = new FacebookApp("My_APP_Id", "MySecret");
        var accessToken = at;
        Facebook.FacebookClient app = new Facebook.FacebookClient(accessToken);
        var result = (Facebook.JsonObject)app.Get("/" + id + "/friends");
        var model = new List<fbUser>();  //model = friendlist array
        int i = 5; //limit to five friends
        foreach (var friend in (Facebook.JsonArray)result["data"])
        {
            if (i != 0)
            {
                model.Add(new fbUser()
                {
                    ID = (string)(((Facebook.JsonObject)friend)["id"]),
                    Name = (string)(((Facebook.JsonObject)friend)["name"])
                });
                i = i - 1;
            }
            else
            {
                break;
            }
        }
        lblreport.Text += "<br/>";
        foreach (fbUser res in model)
        {
            lblreport.Text += res.ID + "<br/>";
            lblreport.Text += res.Name + "<br/>";
        }
       }
