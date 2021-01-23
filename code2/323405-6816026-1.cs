    [DataContract]
    public class Entity
    {
        private const string YourOwnFormat = "dd.MM.yyyy";
    
        public DateTime DateTime
        {
            get;
            set;
        }
    
        [DataMember(Name = "DateTime")]
        private string DateTimeString
        {
            get
            {
                return DateTime.ToString(YourOwnFormat, CultureInfo.InvariantCulture);
            }
            set
            {
                DateTime =
                    DateTime.ParseExact(value, YourOwnFormat, CultureInfo.InvariantCulture);
            }
        }
    }
