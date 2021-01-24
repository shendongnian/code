    [HttpPost]
            [Route("mapchanged")]
            public ActionResult mapchanged(LongLat obj)
            {
                Session["Latitude"] = obj.latitud;
                Session["Longitude"] = obj.longitud;
                //return RedirectToAction("search?what=&by=bnm");
                return Json(new {url = "search?what=&by=bnm"});
            }
    
            public class LongLat
            {
                public double latitud { get; set; }
                public double longitud { get; set; }
            }
