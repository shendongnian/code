    var token = "[your access token]";
    var fb = new Facebook.FacebookClient(token);
    var postId = "173213306032925_74xxxxxxxxxxxxx"; //replace this with your big id which comprises of [userid]_[postid]
    var parameters = new Dictionary<string, object>();
    parameters.Add("message", "test message");
    Console.WriteLine(fb.Post(id+"/comments", parameters).ToString());       // should give new comment's id
    Console.WriteLine(fb.Get(postId +"/comments").ToString());    //should give you details
    //for deleting
    fb.Delete(newly_created_comment_id);   //should return true or false
