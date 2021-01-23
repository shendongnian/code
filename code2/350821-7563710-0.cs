    return new LargeJsonResult
    {
        MaxJsonLength = int.MaxValue,
        JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet,
        Data = new GridModel<MyViewModel>
        {
            Data = model.MyViewModel
        }
    };
