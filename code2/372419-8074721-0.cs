    try
    {
        Service.DoSomeThing();
    }
    catch (Exception err)
    {
        err.CopyTo(ModelState);
    }
