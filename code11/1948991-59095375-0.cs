    public class PhoneNumber : ValueObject {
        public PhoneNumber(string number) {
            Number = phoneNumber;
        }
        [Phone]
        public string Number { get; private set; }
        
        //...
    }
    
