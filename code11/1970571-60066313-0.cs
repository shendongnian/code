    public class Meta
    {
        [JsonProperty("/workers/assignments/myItems")]
        public ItemsMeta Items { get; set; }
    }
    public class ItemsMeta
    {
        public CodeList codeList { get; set; }
    }
    public class CodeList
    {
        public List<ListItem> listItems { get; set; }
    }
    public class ListItem
    {
        public string codeValue { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
    }
    public class Rootobject
    {
        public Meta Meta { get; set; }
    }
