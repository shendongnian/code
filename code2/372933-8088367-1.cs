    string msg = "";
    for (int i = 0; i < max; i++)
    {
        msg += "Your total is ";
        msg += "$500 ";
        msg += DateTime.Now;
    }
    StringBuilder msg_sb = new StringBuilder();
    for (int j = 0; j < max; j++)
    {
        msg_sb.Append("Your total is ");
        msg_sb.Append("$500 ");
        msg_sb.Append(DateTime.Now);
    }
