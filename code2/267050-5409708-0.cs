    public ActionResult Image()
    {
        byte[] imageData = ...
        return File(imageData, "image/png");
    }
