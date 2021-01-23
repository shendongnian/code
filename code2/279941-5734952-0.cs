    // Base requirements for user registration.
    public interface IUserRegistrationView {
    	string FirstName { get; }
    	string LastName { get; }
    	string EmailAddress { get; }
    	string Password { get; }
    }
    
    public interface ISelfRegistrationView : IUserRegistrationView {
    	string CreditCardNumber { get; }
    	CardType CreditCardType { get; }
    	DateTime CreditCardExpirationDate { get; }    
    }
