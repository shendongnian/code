    [HttpPost]
    public ActionResult MyModelAction(FormCollection parameters)
    {
        switch (parameters["OurVersionDisambiguator"])
        {
            case "V1":
                var myModel_V1 = new MyModel_V1();
                var hasModelStateError /* ignoring */ =
                    TryUpdateModel(myModel_V1, parameters.ToValueProvider());
                return MyModelAction(myModel_V1);
            case "V2":
                var myModel_V2 = new MyModel_V2();
                var hasModelStateError /* ignoring */ =
                    TryUpdateModel(myModel_V2, parameters.ToValueProvider());
                return MyModelAction(myModel_V2);
            default: throw new NotImplementedException();
        }
    }
    [NonAction]
    public ActionResult MyModelAction(MyModelV1 myModelV1) 
    {
        // process the model
    }
    [NonAction]
    public ActionResult MyModelAction(MyModelV2 myModelV2) 
    {
        // process the model
    }
