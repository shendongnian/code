    public ActionResult Index()
    {
        MembershipUser currentUser = Membership.GetUser();
        Guid UserId = (Guid)currentUser.ProviderUserKey;
        using (var db = new MatchGamingEntities())
        {
            var myAccount = (from m in db.Account.Include("aspnet_BankTransactions")
                             where m.UserId = UserId
                             select new BankStatement{Balance = (decimal)m.Balance, MyTransactions = m.aspnet_BankTransactions).Single();
            return View(myAccount);
        }
    }
