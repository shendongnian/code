        class Program
        {
            static void Main(string[] args)
            {
                List<TerminalLink> asBuiltList = new List<TerminalLink>();
                var groups = asBuiltList
                    .Select(x => new { TerminalName = x.TerminalName, TerminalType = x.TerminalType, ChannelGroups = x.ChannelGroups.Where(y => y.IsLinkMatch("Apple", 123, 456)) })
                    .Where(x => x.ChannelGroups.Count() > 0)
                    .ToList(); 
            }
        }
        public class TerminalLink
        {
            public string TerminalName { get; set; }
            public string TerminalType { get; set; }
            public ChannelGroupLink[] ChannelGroups { get; set; }
        }
        public class ChannelGroupLink
        {
            public string GroupName { get; set; }
            public int ItemType { get; set; }
            public int SubType { get; set; }
            public ChannelLink[] Channels { get; set; }
            public Boolean IsLinkMatch(string groupName, int itemType, int subType)
            {
                return (this.GroupName == groupName) && ( this.ItemType == itemType) && (this.SubType == subType);
            }
        }
        public class ChannelLink
        {
            public string ChannelName { get; set; }
            public string PathName { get; set; }
            public string DataType { get; set; }
            public bool IsOutput { get; set; }
        }
