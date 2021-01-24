    [Serializable]
    public class Foo
    {
        [XmlIgnore]
        public int[] MyList { get; set; }
        [XmlAttribute(AttributeName = "MyList")]
        public string MyListProxy
        {
            get
            {
                if (MyList == null) return String.Empty;
                return String.Join(" ", MyList);
            }
            set
            {
                MyList = String.IsNullOrWhiteSpace(value) ? new int[0] : value
                    .Split(' ')
                    .Select(a => int.Parse(a))
                    .ToArray();
            }
        }
    }
