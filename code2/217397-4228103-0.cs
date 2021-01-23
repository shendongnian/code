    class Company {
        Address _mailingAddress;
        [DisplayName("Mailing Address")]
        public string MailingAddress {
            get {
                if (_mailingAddress==null) {
                     return null;
                }
                return _mailingAddress.GetAdressString();
            }
        }
    }
            
