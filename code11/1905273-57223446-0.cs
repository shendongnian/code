    public class Example
    {
        private DateTime? _birthdate;
    
        public DateTime? Birthdate
        {
            get => _birthdate;
    
            set
            {
                _birthdate = value;
                if (value != null)
                {
                    BirthDayAndMonth = GetAnnualBirthday(value.Value.Month, value.Value.Day);
                }
            }
        }
    
        public Date? BirthDayAndMonth { get; private set; }
    }
