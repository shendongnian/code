    public partial class Card {
        public string entry_type { get; set; }
        public string number { get; set; }
        public string expiration_date { get; set; }
        public long cvc { get; set; }
        public CardholderAuthentication cardholder_authentication { get; set; }
    }
    public partial class CardholderAuthentication {
        public string condition { get; set; }
        public string eci { get; set; }
        public string cavv { get; set; }
        public string xid { get; set; }
    }
