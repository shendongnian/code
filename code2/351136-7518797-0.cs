    var cpy = new Payment()
    {
        //pk
        ID = orig.ID,
        //other fields
        Information = orig.Information,
        Amount = orig.Amount,
        Approved = orig.Approved,
        AwardedPoints = orig.AwardedPoints,
        DateReceived = orig.DateReceived
    };
    //create stub entity for the Method and Add it.
    var method = new Method{MethodId=orig.MethodId)
    _ctx.AttachTo("Methods", method);
    cpy.Methods.Add(method);
    //attach it
    _ctx.MyEntities.Attach(cpy, o);
    //submit the changes
    _ctx.SubmitChanges();
