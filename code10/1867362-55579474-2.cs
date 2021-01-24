    class ContentItem {
        public string Prefix {get;set; }
        public int Depth {get;set; }
        public string Name {get;set; }
        public override string ToString() {
            return $"{Prefix}{(new String("-", Depth))} {Name}";
        }
    }
