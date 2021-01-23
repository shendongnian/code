        private class Dollar
        {
            [DecimalPlacesContract (MinimumMantissaCount = "0", MaximumMantissaCount = "2")]
            public decimal Amount { get; set; }
        }
        private class DollarProper
        {
            [DecimalPlacesContract (MinimumSignificantDigitCount = "2", MaximumSignificantDigitCount = "2")]
            public decimal Amount { get; set; }
        }
