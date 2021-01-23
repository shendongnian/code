    List<string> results = new List<string>();
    for (int i = 1; i <= amount_selected; i++)
    {
        string s = String.Format("{0}", Request.Form["variable" + Convert.ToString(i)]);
        results.Add(s);
    }
