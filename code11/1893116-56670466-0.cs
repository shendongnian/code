    [OutputCache(NoStore = true, 
                 Location = System.Web.UI.OutputCacheLocation.Client,
                 Duration = 10)]
    public ActionResult Data()
    {
        NGTransCertDBHandle certDBHandle = new NGTransCertDBHandle();
        List<NGTransCertServicesList> List_certServices = certDBHandle.GetService();
        NGT_VM.NGTransServicesList = List_certServices;
        return PartialView("_Data", NGT_VM);
    }
