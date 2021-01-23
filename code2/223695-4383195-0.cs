    [WebMethod()]
    [ScriptMethod(UseHttpGet=true, ResponseFormat=ResponseFormat.Json)]
    public CarCollection GetCars()
    {
        CarCollection carResult = new CarCollection ();
        ...
        return car;
    }
