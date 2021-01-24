    public class LoanCalculator
    {
        public  decimal Amnt;
        public double MonthlyInstallment;
        public string CanTakeLoan;
        private string ex;
        public decimal Calculator(double Amount, double Months)
        {
            try
            {
                var Rate = 0.75;
                double LoanLimit = 0.25 * Salary;
                if( (!CanTakeLoanFn(Amount, Months))
                {
                    // Do not assign anything here. Handle you text 
                    // where you need it.
                    // If you want to handle it here, then declare it as
                    // A class member
                    this.CantTakeLoan = "Please Not That You Cant Take Loan";
                }
                else
                {                    
                }
            }
            catch (Exception ex)
            {
            }
             return Amnt;
        }
    }
    public boolean CanTakeLoanFn(double Amount, double Months) {
        MonthlyInstallment = Amount / ((Math.Pow(1 + Rate, Months) - 1) / (Rate * Math.Pow(1 + Rate, Months)));
        double LoanLimit = 0.25 * Salary;
        return (MonthlyInstallment  > LoanLimit);
    }
And then in you Aspx:
protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
               var loanCalculator = new LoanCalculator();
               if(!loanCalculator.CanTakeLoan(value1, value2)) {
                    // Do your logic here
               }
            }
            catch(Exception ex)
            {
            }
        }
You can also change the `Calculator` function to constructor and use like this
   public class LoanCalculator
    {
        public  decimal Amnt;
        public double MonthlyInstallment;
        public string CanTakeLoan;
        private string ex;
        public LoanCalculator(double Amount, double Months)
        {
            try
            {
                var Rate = 0.75;
                double LoanLimit = 0.25 * Salary;
                if( (!CanTakeLoanFn(Amount, Months))
                {
                    // Do not assign anything here. Handle you text 
                    // where you need it.
                    // If you want to handle it here, then declare it as
                    // A class member
                    this.CantTakeLoan = "Please Not That You Cant Take Loan";
                }
                else
                {                    
                }
            }
            catch (Exception ex)
            {
            }
            this.Amnt = // Set the amount here
        }
    }
    public boolean CanTakeLoanFn(double Amount, double Months) {
        MonthlyInstallment = Amount / ((Math.Pow(1 + Rate, Months) - 1) / (Rate * Math.Pow(1 + Rate, Months)));
        double LoanLimit = 0.25 * Salary;
        return (MonthlyInstallment  > LoanLimit);
    }
And in Aspx
protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
               var loanCalculator = new LoanCalculator(value1, value2);
               loanCalculator.Amnt // this is the amount variable
               loanCalculator.CanTakeLoan // this is the string variable with the text
            }
            catch(Exception ex)
            {
            }
        }
