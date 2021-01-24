    public ActionResult SessionCheck()
     {
       string message = string.Empty;
       if (Session["UserName"] == null)
        {
          message = "Session expired. Please Login again";
        }
        return Json(message, JsonRequestBehavior.AllowGet);
      }
