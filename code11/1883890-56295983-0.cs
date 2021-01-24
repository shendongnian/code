    private void button1_Click(object sender, EventArgs e)
    {
        textBoxLog.Clear();
        var regionList = BuildList();
        var regex = BuildRegex(regionList.Keys);
        TryMatch("B20 7TP", regionList, regex);
        TryMatch("BT1 1AB", regionList, regex);
        TryMatch("TR21 1AB", regionList, regex);
        TryMatch("TR0 00", regionList, regex);
        TryMatch("XX123", regionList, regex);
    }
    private static IReadOnlyDictionary<string, string> BuildList()
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        result.Add("AL", "St Albans");
        result.Add("B", "Birmingham");
        result.Add("BT", "Belfast");
        result.Add("TR", "Taunton");
        result.Add("TR21", "Taunton X");
        result.Add("TR22", "Taunton Y");
        return result;
    }
    private static Regex BuildRegex(IEnumerable<string> codes)
    {
        // Sort the code by length descending so that for example TR21 is sorted before TR and is found by regex engine
        // before the shorter match
        codes = from code in codes
                orderby code.Length descending
                select code;
        // Escape the codes to be used in the regex
        codes = from code in codes
                select Regex.Escape(code);
        // create Regex Alternatives
        string codesAlternatives = string.Join("|", codes.ToArray());
        // A regex that starts with any of the codes and then has any data following
        string lRegExSource = "^(" + codesAlternatives + ").*";
        return new Regex(lRegExSource, RegexOptions.IgnoreCase | RegexOptions.Singleline);
    }
    /// <summary>
    /// Try to match the postcode to a region
    /// </summary>
    private bool CheckPostCode(string postCode, out string identifiedRegion, IReadOnlyDictionary<string, string> regionList, Regex regex)
    {
        // Check whether we have any match at all
        Match match = regex.Match(postCode);
        bool result = match.Success;
        if (result)
        {
            // Take region code from first match group
            // and use it in dictionary to get region name
            string regionCode = match.Groups[1].Value;
            identifiedRegion = regionList[regionCode];
        }
        else
        {
            identifiedRegion = "";
        }
        return result;
    }
    private void TryMatch(string code, IReadOnlyDictionary<string, string> regionList, Regex regex)
    {
        string region;
        if (CheckPostCode(code, out region, regionList, regex))
        {
            AppendLog(code + ": " + region);
        }
        else
        {
            AppendLog(code + ": NO MATCH");
        }
    }
    private void AppendLog(string log)
    {
        textBoxLog.AppendText(log + Environment.NewLine);
    }
