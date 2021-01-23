    [HttpPost]
    public ActionResult MyPostAction( string foo, string bar )
    {
         ...
         return Json( new { Value = "baz" } );
    }
