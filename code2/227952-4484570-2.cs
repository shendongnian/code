    // Probably needs a better name.
    struct YearAndAccount
    {
        private readonly int budgetYear;
        private readonly string accountId;
        
        public int BudgetYear { get { return this.budgetYear; } }
        public string AccountId { get { return this.accountId; } }
        
        public YearAndAccount(int budgetYear, string accountId)
        {
            this.budgetYear = budgetYear;
            this.accountId = accountId;
        }
    }
    var rows = XDocument.Load("filename.xml")
                        .Root.Elements()
                        .Select(row => new YearAndAccount(
                            int.Parse(row.Elements().Single(el => el.Attribute("name").Value == "budgetYear")
                                                          .Attribute("value").Value),
                            row.Elements().Single(el => el.Attribute("name").Value == "account")
                                          .Attribute("value").Value));
