    public static async Task<double> CalculatePrincipal(IBankingModel bm)
     {
          await Task.Run(() =>
          {
               //... some time-consuming operation
               Principal = bm.LoanAmount - InterestRate;
          });       
          return Principal;    
     } 
