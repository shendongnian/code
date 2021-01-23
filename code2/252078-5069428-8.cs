sealed class WarnCodeProcessor
{
    private static Dictionary&lt;int, WarnCodeValue> warnCodesDictionary;
    private static volatile WarnCodeProcessor _instance;
    private static object instanceLockCheck = new object();
    public static WarnCodeProcessor Instance
    {
        get
        {
            lock (instanceLockCheck)
            {
                if (_instance == null)
                {
                    _instance = new WarnCodeProcessor();
                }
            }
            return _instance;
        }
    }
    private WarnCodeProcessor()
    {
        warnCodesDictionary = new Dictionary&lt;int, WarnCodeValue>();
        string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string settingsFilePath = Path.Combine(currentDirectory, "WarnCodes.xml");
        XElement rootElement = XElement.Load(settingsFilePath);
        warnCodesDictionary = GetChildren(rootElement, string.Empty);
    }
    public string GetConcatenatedMeaning(int code)
    {
        string concatenatedMeaning = string.Empty;
        int firstLevel = code & 0xF000;
        int secondLevel = code & 0xFF00;
        int thirdLevel = code & 0xFFF0;
        if (warnCodesDictionary.ContainsKey(firstLevel))
        {
            concatenatedMeaning = warnCodesDictionary[firstLevel].ConcatenatedMeaning;
            if (warnCodesDictionary[firstLevel].ChildNodes != null &&
                warnCodesDictionary[firstLevel].ChildNodes.ContainsKey(secondLevel))
            {
                concatenatedMeaning = 
                    warnCodesDictionary[firstLevel].
                    ChildNodes[secondLevel].ConcatenatedMeaning;
                if (warnCodesDictionary[firstLevel].ChildNodes[secondLevel].ChildNodes != null &&
                    warnCodesDictionary[firstLevel].ChildNodes[secondLevel].ChildNodes.ContainsKey(thirdLevel))
                {
                    concatenatedMeaning = 
                        warnCodesDictionary[firstLevel].
                        ChildNodes[secondLevel].
                        ChildNodes[thirdLevel].ConcatenatedMeaning;
                    if (warnCodesDictionary[firstLevel].ChildNodes[secondLevel].ChildNodes[thirdLevel].ChildNodes != null &&
                        warnCodesDictionary[firstLevel].ChildNodes[secondLevel].ChildNodes[thirdLevel].ChildNodes.ContainsKey(code))
                    {
                        concatenatedMeaning = 
                            warnCodesDictionary[firstLevel].
                            ChildNodes[secondLevel].
                            ChildNodes[thirdLevel].
                            ChildNodes[code].ConcatenatedMeaning;
                    }
                }
            }
        }
        return concatenatedMeaning;
    }
    private static Dictionary&lt;int, WarnCodeValue> GetChildren(XElement element, string concatenatedMeaning)
    {
        string elementMeaning = string.Empty;
        XAttribute attribute = element.Attribute("meaning");
        if (attribute != null)
        {
            elementMeaning = attribute.Value;
            concatenatedMeaning =
                string.IsNullOrEmpty(concatenatedMeaning) ? elementMeaning : string.Format("{0} : {1}", concatenatedMeaning, elementMeaning);
        }
        if (element.Descendants().Count() > 0)
        {
            Dictionary&lt;int, WarnCodeValue> childNodeDictionary = new Dictionary&lt;int, WarnCodeValue>();
            foreach (XElement childElement in element.Elements())
            {
                int hex = Convert.ToInt32(childElement.Attribute("hex").Value, 16);
                string meaning = childElement.Attribute("meaning").Value;
                Dictionary&lt;int, WarnCodeValue> dictionary = GetChildren(childElement, concatenatedMeaning);
                WarnCodeValue warnCodeValue = new WarnCodeValue();
                warnCodeValue.ChildNodes = dictionary;
                warnCodeValue.Meaning = meaning;
                warnCodeValue.ConcatenatedMeaning =
                    string.IsNullOrEmpty(concatenatedMeaning) ? meaning : string.Format("{0} : {1}", concatenatedMeaning, meaning);
                childNodeDictionary.Add(hex, warnCodeValue);
            }
            return childNodeDictionary;
        }
        return null;
    }
}
