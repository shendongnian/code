    class DataItem : ListItem
    {
        public string Date { set; get; }
        public override int getType()
        {
            return TYPE_HEADER;
        }
    }
