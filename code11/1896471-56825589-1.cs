    public class User : IdentityUser
    {
        public virtual List<UserCurrency> UserFavoriteCurrencies { get; set; } = new List<UserCurrency>();
    }
    
