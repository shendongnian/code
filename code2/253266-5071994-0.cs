    string str = String.Concat(
        "var rawItemInfo={",
        string.Join(",", "\"stock\":\"In stock. Limit 5 per customer.\"",
                         "\"shipping\":\"$19.99 Shipping\"",
                         "\"finalPrice\":\"139.99\"",
                         "\"itemInfo\":\"<div class=\\\"grpPricing\\\" />\""),
        "}");
    var item = @"""(?<key>[^""]+)"":""(?<value>(?:[^\\""]|\\"")+)""";
    var jsonRe = new Regex("\\{" + item + "(?:," + item + ")*\\}", RegexOptions.Compiled);
    var m = jsonRe.Match(str);
    var json = new System.Collections.Specialized.StringDictionary();
    if (m.Success)
    {
        int captures = m.Groups["key"].Captures.Count;
        for (int i = 0; i < captures; i++)
        {
            json[m.Groups["key"].Captures[i].Value] = m.Groups["value"].Captures[i].Value;
        }
    }
    var val1 = json["stock"];       // "In stock. Limit 5 per customer."
    var val2 = json["shipping"];    // "$19.99 Shipping"
    var val3 = json["finalPrice"];  // "139.99"
    var val4 = json["itemInfo"];    // "<div class=\\\"grpPricing\\\" />"
