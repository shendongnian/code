    string str = String.Concat(
        "var rawItemInfo={",
        string.Join(",", "\"stock\":\"In stock. Limit 5 per customer.\"",
                         "\"shipping\":\"$19.99 Shipping\"",
                         "\"finalPrice\":\"139.99\"",
                         "\"itemInfo\":\"<div class=\\\"grpPricing\\\" />\""),
        "}");
    // recognize a JSON* object
    var item = @"""(?<key>[^""]+)""\s*:\s*""(?<value>(?:[^\\""]|\\"")+)""";
    var jsonRe = new Regex(@"\{\s*" + item + @"(?:\s*,\s*" + item + @")*\s*\}", RegexOptions.Compiled);
    var m = jsonRe.Match(str);
    // build the corresponding dictionary
    var json = new System.Collections.Specialized.StringDictionary();
    if (m.Success)
    {
        int captures = m.Groups["key"].Captures.Count;
        for (int i = 0; i < captures; i++)
        {
            json[m.Groups["key"].Captures[i].Value] = m.Groups["value"].Captures[i].Value;
        }
    }
    // get the values
    var val1 = json["stock"];       // "In stock. Limit 5 per customer."
    var val2 = json["shipping"];    // "$19.99 Shipping"
    var val3 = json["finalPrice"];  // "139.99"
    // extract price from val2
    val2 = Regex.Replace(val2, @"\$(\d+\.\d{2}|free) Shipping", @"$1"); // "19.99"
