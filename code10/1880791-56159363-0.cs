        private double _amount;
        public double Amount
        {
            get => _amount;
            set
            {
                if (_amount == value) return;
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                OnPropertyChanged(nameof(FormattedAmount));
            }
        }
        private string _currency;
        public string Currency
        {
            get => _currency;
            set
            {
                if (_currency == value) return;
                _currency = value;
                OnPropertyChanged(nameof(Currency));
                OnPropertyChanged(nameof(FormattedAmount));
            }
        }
        public string FormattedAmount
        {
            get
            {
                switch (Currency)
                {
                    case "JPY":
                        return Amount.ToString("N0");
                    default:
                        return Amount.ToString("N2");
                }
            }
            set
            {
                if (double.TryParse(value, out var amount))
                    Amount = amount;
                else
                    OnPropertyChanged(nameof(FormattedAmount));
            }
        }
