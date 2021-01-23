    public ActionResult Index(string form_element)
    {
        if (form_element != null ) {
            form_element = "some new value"; // not sure, why u need this. :)
        }
        return new CustomActionResult(this);
    }
