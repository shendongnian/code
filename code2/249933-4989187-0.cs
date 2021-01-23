    //error prone to malformed brackets...
    string s = "Hello {0} Bye {1} {0} {34}";
    int param = -1;
    foreach (string sub in s.Split("{}".ToCharArray()))
    {
        int thisparam;
        if (Int32.TryParse(sub, out thisparam) && param < thisparam)
                param = thisparam;
    }
