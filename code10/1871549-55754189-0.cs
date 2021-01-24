        public class DTO
        {
            private string _value { get; set; }
            public string Value
            {
                get { return Encoding.UTF8.GetString(_value.Select(x => (byte)((int)x)).ToArray()); }
                set { _value = value; }
            }
        }
