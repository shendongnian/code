        class CreditCard
    {
        public string ExpirationYear { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationDate
        {
            get
            {
                return string.Format("{0}/{1}", ExpirationMonth, ExpirationYear);
            }
        }
    }
