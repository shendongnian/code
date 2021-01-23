    String urlToSearch = "http://example.com/TIGS/SIM/Lists/Team Discussion/DispForm.aspx";
    String result = "";
    // First, get everthing after "/Lists/"
    string[] temp1 = urlToSearch.Split(new String[] { "/Lists/" }, StringSplitOptions.RemoveEmptyEntries);                
    if (temp1.Length > 1)
    {
        // Next, get everything before the first "/"
        string[] temp2 = temp1[1].Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        result = temp2[0];
    }
