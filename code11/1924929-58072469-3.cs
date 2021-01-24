    class Email:ListItem
    {
        public string date { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public override int getType()
        {
            return TYPE_CONTENT;
        }
    }
