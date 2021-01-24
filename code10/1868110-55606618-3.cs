        public class item
        {
            public string id { get; set; }
            public string type { get; set; }
        }
        public class itemDto
        {
            public string id { get; set; }
            public string type { get; set; }
        }
        public itemDto Convert(item source)
        {
            itemDto target = new itemDto();
            target.id = source.id;
            target.type = source.type;
            return target;
        }
