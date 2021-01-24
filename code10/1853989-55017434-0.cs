    if (DDL1.DataValueField == "Easy")
    {
        Response.Redirect("/My code/GuessTheNumber.aspx", true);
    }
    else if (DDL1.DataValueField == "Medium")
    {
        Response.Redirect("~/Medium.aspx", true);
    }
    else if (DDL1.DataValueField == "Hard")
    {
        Response.Redirect("~/Hard.aspx", true);
    }
