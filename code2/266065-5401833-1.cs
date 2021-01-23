     public class Account
        {
            [Key]
            public int Id { get; set; }
            public string MyOutputParameter { get; set; }
    
            [Include, Association("Account_AccountDetails", "Id", "AccountId")]
            public List<AccountDetail> AccountDetails { get; set; }
        }
    
