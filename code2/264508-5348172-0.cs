    public ActionResult Deposit(DepositTicket dt)
    {
        using (var db = new MatchGamingEntities())
        {
            MembershipUser currentUser = Membership.GetUser();
            Guid UserId = (Guid)currentUser.ProviderUserKey;
            var MyAccount = db.Accounts.SingleOrDefault(a => a.UserId == UserId);
            BankTransaction transaction = new BankTransaction();
            transaction.Amount = dt.Amount;
            transaction.AccountId = MyAccount.AccountId;
            transaction.Created = DateTime.Today;
            transaction.TransactionType = "Credit";
            Debug.Write(String.Format("Amount: {0} AccountId: {1}", transaction.Amount, transaction.AccountId);
            db.BankTransactions.AddObject(transaction);
            MyAccount.Balance += transaction.Amount;
            db.SaveChanges();
            return View();
        }
