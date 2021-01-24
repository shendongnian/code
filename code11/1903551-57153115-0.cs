[HttpGet]
public ActionResult Teeeest()
{
   ViewBag.ViedoFileName = "vid2.mp4";
   return PartialView("Videos");
}
