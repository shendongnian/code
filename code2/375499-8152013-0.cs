    public class Record
    {
        public string ItemType { get; set; }
        public string this[string propertyName]
        {
            set
            {
                switch (propertyName)
                {
                    case "itemType":
                        ItemType = value;
                        break;
                        // etc
                }   
            }
        }
    }
