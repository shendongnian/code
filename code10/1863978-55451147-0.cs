    private decimal totalPriceDecimal;
    private string totalPriceString;
        public string TotalPrice
        {
            get
            {
                return this.totalPriceString();
            }
            set
            {
                this.totalPriceString = value;
                decimal temp;
                if (int.TryParse(value, out temp))
                {
                    this.totalPriceDecimal = temp;
                }
            }
        }
