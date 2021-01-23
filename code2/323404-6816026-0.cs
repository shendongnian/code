    [DataContract]
    public class Entity
    {
        private const string YourOwnFormat = "dd.MM.yyyy";
    
        public DateTime DateTime
        {
            get;
            set;
        }
    
        /// <summary>
        /// For private usage only!
        /// </summary>
        [DataMember]
        public string DateTimeString
        {
            get
            {
                return DateTime.ToString(YourOwnFormat, CultureInfo.InvariantCulture);
            }
            private set
            {
                DateTime =
                    DateTime.ParseExact(value, YourOwnFormat, CultureInfo.InvariantCulture);
            }
        }
    }
