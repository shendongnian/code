    public ActionResult FooDetail()
    {
      if(heads_or_tails)
      {
         return Content("string_to_pass");
      }
      else
      {
         return RedirectToAction("action_name");
      }
    }
