    class BankAccountProtected
    {
        public void CloseAccount()
        {
            ApplyPenalties();
            CalculateFinalInterest();
            DeleteAccountFromDB();
        }
    
        protected virtual void ApplyPenalties()
        {
            // deduct from account
        }
    
        protected virtual void CalculateFinalInterest()
        {
            // add to account
        }
    
        protected virtual void DeleteAccountFromDB()
        {
            // send notification to data entry personnel
        }
    }
