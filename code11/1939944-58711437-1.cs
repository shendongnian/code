var c = new SomeClass();
foreach( var item in c ) 
{
   What to iterate through here? 
}
----
A method that returns multiple object would look something like the following.
public ActionResult Details(sring clientName )
{
    if (string.IsNUllOrEmpty(clientName))
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    var svs = db.SingleViews.Where( sv => sv.Client == clientName).ToList();
    if (!svs.Any())
    {
        return HttpNotFound();
    }
    return View(svs);
}
The `Model` for this view would be a collection and then you can use `foreach`. 
