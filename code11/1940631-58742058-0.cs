    [HttpPost] 
    public ActionResult PostData(FormCollection collection)
    {
        // Get Post Params Here
        string p1 = collection["param1"];
        string p2 = collection["param2"];
    }
