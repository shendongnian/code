    public string RecursiveMethod()
    {
        string response = "fail";
        
        if (someOtherConditionApplies)
            response = "success";
        if (response == "fail")
        {
            response = RecursiveMethod();
        }
        return response;
    }
