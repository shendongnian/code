c#
 public class Loan
    {
        [Key] 
        public int LoanID { get; set; }
        [Column(TypeName = "nvarchar(250)"), Required]
        public string Details { get; set; }
        [Column(TypeName = "nvarchar(10)")] 
        public string BorrowerName { get; set; }
        [Column(TypeName = "nvarchar(100)")] 
        public string FundingAmount { get; set; }
        [Column(TypeName = "nvarchar(100)")] 
        public string RepaymentAmount { get; set; }
    }
And then I deleted your init migration and added a new one. I tested that migration with SQL server and SQLite and it was fine. 
Just be sure when you are using slite you should set the connection string like this 
 > "Data Source=loanDb.db"
**note:** It is better to use decimal for "FundingAmount" and "RepaymentAmount" fields instead of string.
