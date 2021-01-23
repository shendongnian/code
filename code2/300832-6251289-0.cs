    var sb = new StringBuilder();
    if (yourList.Count > 0)
    {
        sb.Append(yourList[0]);
        if (yourList.Count > 1)
        {
            for (int i = 1; i < yourList.Count - 1; i++)
            {
                sb.Append(", ").Append(yourList[i]);
            }
            sb.Append(" and ").Append(yourList[yourList.Count - 1]);
        }
    }
    string values = sb.ToString();
    
