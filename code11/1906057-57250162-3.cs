    public class AccountLoginConverter : ITypeConverter<AccountLogin, LoginUserResponseModel>
    {
        public LoginUserResponseModel Convert(AccountLogin source, LoginUserResponseModel destination, ResolutionContext context)
        {
            if(source == null)
            {
                return new LoginUserResponseModel { AccountExists = false, Status = "Error" }
            }
            // You can have more complex logic here      
            return new LoginUserResponseModel
            {
                AccountExists = true,
                AccountVerified = true, // Or more logic
                Status = "Ok"
            };
        }
    }
