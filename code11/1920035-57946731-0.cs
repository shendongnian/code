    public ActionResult ManageData(string type) 
    {
        switch (type) {
            case 'first':
                return View(new BaseData<FirstType>().GetSharedData());
            case 'second':
                return View(new BaseData<SecondType>().GetSharedData());
            default:
                return View();
        }
    }
