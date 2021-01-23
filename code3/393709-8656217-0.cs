    public class ActionReportEntity
    {
        private String[] items = new String[10];
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Item1 { get { return items[0]; } set { items[0] = value; } }
        public string Item2 { get { return items[1]; } set { items[1] = value; } }
        public string Item3 { get { return items[2]; } set { items[2] = value; } }
        public string Item4 { get { return items[3]; } set { items[3] = value; } }
        public string Item5 { get { return items[4]; } set { items[4] = value; } }
        public string Item6 { get { return items[5]; } set { items[5] = value; } }
        public string Item7 { get { return items[6]; } set { items[6] = value; } }
        public string Item8 { get { return items[7]; } set { items[7] = value; } }
        public string Item9 { get { return items[8]; } set { items[8] = value; } }
        public string Item10 { get { return items[9]; } set { items[9] = value; } }
        public void UpdateItem(Int32 index, String value)
        {
            if (index >= items.Length)
                throw new ArgumentException();
            items[index] = value;
        }
        public void UpdateItem(params String[] values)
        {
            if (values.Length != items.Length)
                throw new ArgumentException();
            for (int i = 0; i < values.Length; i++)
            {
                items[i] = values[i];                
            }
        }
    }
