    [TypeConverter(typeof(BarConverter))]
    public struct Bar
    {
        public Bar(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
    }
