    public ActionResult LogInAndInitiate(FormCollection formValues, string phone, string method)
    {
        var ModelB = new ModelB();
        var ModelA = new ModelA(); // passed in, so its not null!
        ModelA.EmailAddress = formValues["EmailAddress"];
        ModelB.Email = ModelA.EmailAddress // passed in too!
        var userId = ModelB.dosomething(ModelB.Email, phone, method);
    }
