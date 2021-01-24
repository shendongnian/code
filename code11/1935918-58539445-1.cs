 public ActionResult CurrentPost(int? id)
 {
      SiteContext db = new SiteContext();
      var post = db.Posts.FirstOrDefault(p => p.PostId == id);
      return PartialView(post);
 }
you can check it on your view to avoid erros.
@if(Model != null)
{
  // your code.
}
else
{
<p>No item found </p>
}
