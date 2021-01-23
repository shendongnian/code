public JsonResult GetJson()
{
  string res;
  WebClient client = new WebClient();
  // Download string
  string value = client.DownloadString("https://api.instagram.com/v1/users/000000000/media/recent/?client_id=clientId");
  // Write values
  res = value;
  dynamic dyn = JsonConvert.DeserializeObject(res);
  var lstInstagramObjects = new List<InstagramModel>();
  
  foreach(var obj in dyn.data)
  {
    lstInstagramObjects.Add(new InstagramModel()
    {
      Link = (obj.link != null) ? obj.link.ToString() : "",
      VideoUrl = (obj.videos != null) ? obj.videos.standard_resolution.url.ToString() : "",
      CommentsCount = int.Parse(obj.comments.count.ToString()),
      LikesCount = int.Parse(obj.likes.count.ToString()),
      CreatedTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double.Parse(obj.created_time.ToString()))),
      ImageUrl = (obj.images != null) ? obj.images.standard_resolution.url.ToString() : "",
      User = new InstagramModel.UserAccount()
             {
               username = obj.user.username,
               website = obj.user.website,
               profile_picture = obj.user.profile_picture,
               full_name = obj.user.full_name,
               bio = obj.user.bio,
               id = obj.user.id
             }
    });
  }
  return Json(lstInstagramObjects, JsonRequestBehavior.AllowGet);
}
