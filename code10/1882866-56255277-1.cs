    public class User
    {
        public string Name { get; set; }
        public Address CurrentAddress { get; set; }
        public List<Phone> PhoneLines { get; set; }
        private DateTime _dummyValue;
        public DateTime GetRenewalDate
        {
            get
            {
                if (this.PhoneLines == null || this.PhoneLines.Count == 0)
                    return DateTime.MinValue;
                else
                {
                    return this.PhoneLines.OrderByDescending(y => y.RenewalDate).Select(y => y.RenewalDate).FirstOrDefault();
                }
            }
            set
            {
                 _dummyValue = value;
            }
        }
     }
