    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Test(NameInfo nameInfo)
    {
        var model = new List<NameInfo>()
        {
            new NameInfo(){ Id=1,FirstName="a",LastName="b",Address=new Address(){ StreetName="aa",ApartmentNumber=1001} },
            new NameInfo(){ Id=2,FirstName="c",LastName="d",Address=new Address(){ StreetName="bb",ApartmentNumber=1002} }
        };
        var data = model.Where(m => m.FirstName == nameInfo.FirstName).Where(m => m.LastName == nameInfo.LastName).Select(m => m.Address).FirstOrDefault();
        return PartialView("_partialAddressInfo",data);
    }
