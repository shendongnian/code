[HttpPost]
[Route("Upload")]
public ActionResult Upload(ItemViewModel itemVm)
{
   var data = itemVm.Example;
   //do something with data
}
if you just send a string you can use a string instead of a vm
[HttpPost]
[Route("Upload")]
public ActionResult Upload(string example)
{   
   //do something with data
}
