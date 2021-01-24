    class DealerInventoryFeedUrlParser
    {
        static Dictionary<string, DealerInventoryLinkPatternParam> GetLinkPatternParamValueMap() => throw new NotImplementedException();
        public virtual string ParseDealerInventoryLink(string toParseLinkData)
        {
            string pattern = "{([^}]+)}";
            string text = toParseLinkData;
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled;
            if (/*this != null &&*/ !string.IsNullOrWhiteSpace(text))
            {
                dynamic dyn = new PropertyBag(this);
                Regex regex = new Regex(pattern, options);
                Dictionary<string, DealerInventoryLinkPatternParam> linkPatternMap = GetLinkPatternParamValueMap();
                text = regex.Replace(text, delegate (Match mat)
                {
                    if (mat.Success && mat.Groups.Count > 0)
                    {
                        Group group = mat.Groups[mat.Groups.Count - 1];
                        if (group.Success)
                        {
                            string value = group.Value;
                            if (linkPatternMap.ContainsKey(value))
                            {
                                return Convert.ToString(dyn[linkPatternMap[value].ColumnName]);
                            }
                        }
                    }
                    return mat.Value;
                });
            }
            return text;
        }
    }
    class PropertyBag
    {
        private readonly object Owner;
        public PropertyBag(object obj)
        {
            Owner = obj;
        }
    }
    class DealerInventoryLinkPatternParam
    {
        public string ColumnName { get; set; }
    }
