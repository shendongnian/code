    if(string.IsNullOrEmpty(Cookies["beta"]))
    {
        var betaModel = DataLayer.GetModelForThisAction();
        Render("BetaView", betaModel);
    }
    else
    {
        var normalModel = DataLayer.GetModelForThisAction();
        Render("NormalView", normalModel);
    }
