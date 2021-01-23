    public ActionResult YourView(TestModel pModel) {
        
        //pMomdel code here
        ViewBag.BlaResult = Bla(pModel);
        return View(pModel);
    }
