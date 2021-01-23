    System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[01][01,]+?[01]");
    if (!reg.IsMatch("3452"))
    {
        Response.Write("Does Not Match");
    }
    if (reg.IsMatch("01111,1"))
    {
        Response.Write("Yes Match!");
    }
