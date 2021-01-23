    [XmlRoot("accounts")]
    public class AccountsDocument {
        [XmlElement("account")]
        public Account[] Accounts { get; set; }
    }
