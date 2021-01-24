        public class Id
        {
            public int Value { get; set; }
        }
        public class ParentLocationGroup
        {
            public int LgLevel { get; set; }
            public string Users { get; set; }
            public string Admins { get; set; }
            public string Devices { get; set; }
            public Id Id { get; set; }
            public string Uuid { get; set; }
        }
        public class RootObject
        {
            public string Name { get; set; }
            public string GroupId { get; set; }
            public string LocationGroupType { get; set; }
            public string Locale { get; set; }
            public ParentLocationGroup ParentLocationGroup { get; set; }
        }
     string jsonString = "[{\"Name\":\"Test\",\"GroupId\":\"UST\",\"LocationGroupType\":\"Container\",\"Locale\":\"en-US\",\"ParentLocationGroup\":{\"LgLevel\":0,\"Users\":\"0\",\"Admins\":\"0\",\"Devices\":\"221\",\"Id\":{\"Value\":5545},\"Uuid\":\"-787d87c8fd3a\"}}]";
     List<RootObject> roots = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
     ParentLocationGroup parent = roots.FirstOrDefault().ParentLocationGroup;
