    public static void PostToWall(string wallPost, string friendId)
    {
        var fb = new FacebookClient(Globals.AccessToken);
        var parameters = new Dictionary<string, object>(); 
        parameters["message"] = wallPost;
        fb.PostAsync(String.Format("{0}/feed", friendId), parameters);
    }
