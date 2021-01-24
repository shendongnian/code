        public partial class amountSetRequest
        {
            private decimal _collectionAmount { get; set; }
            public string collectionAmount {
                get {return _collectionAmount.ToString("F2");}
                set {_collectionAmount = decimal.Parse(value);}
            }
        }
