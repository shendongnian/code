    class ItemDesc
    {
        public string Ident { get; private set; }
        public string Fields { get; private set; }
        public ItemDesc(string id, string flds)
        {
            Ident = id;
            Fields = flds;
        }
    }
