static Dictionary<string, string> dict = new Dictionary<string, string>() {
    { "hostSW", "{0}*" },
    { "hostCN", "*{0}*" },
    { "hostEW", "*{0}" },
};
static IEnumerable<string> WildcardStringsFromXML(XDocument xdoc)
{
    return xdoc.Root.Descendants("Test").Elements()
               .Select(item => string.Format(dict[item.Name.LocalName], item.Value));
}
