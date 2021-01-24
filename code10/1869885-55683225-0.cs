     public class BankApplicationDAL : IBankApplicationDAL
     {
                DataContext _context;
                public BankApplicationDAL(DataContext context)
                {
                    _context = context;
                }
                
                public AccountDetails GetAccountDetailsId(int userId)
                {
                    try
                    {
                        var values = context.AccountDetails.FirstOrDefault(x => x.UserId == userId); // context is null here.
                        return values;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
       }
