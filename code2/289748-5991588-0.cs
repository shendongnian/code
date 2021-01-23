    public ActionResult Show(int ID, string param1 = null, int? param2 = null)
    {
        return View(/*.GetShow(ID, param1, param2)*/);
    }
    [HttpMethod.Post]
    public ActionResult Show(FormCollection collection)
    {
        return RedirectToAction("Show", new { ID = collection["ID"], param1 = collection["param1"], param2 = collection["param2"] });
    }
