    public System.Web.Mvc.ActionResult GenerateSDCFromTBox()
    {
        Stream stream = Request.Content.ReadAsStreamAsync().Result;
        // return do what ever with stream
    }
