    [HttpPost]
    public ActionResult Uploadfile(int id, HttpPostedFileBase file)
    {
        Containers containers = Repository.GetContainers(id);
        ...
    }
