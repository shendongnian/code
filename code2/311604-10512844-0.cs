       public class Invoice
    {
      public string Company { get; set; }
      public decimal Amount { get; set; }
     
      // false is default value of bool
      public bool Paid { get; set; }
      // null is default value of nullable
      public DateTime? PaidDate { get; set; }
     
      // customize default values
      [DefaultValue(30)]
      public int FollowUpDays { get; set; }
      [DefaultValue("")]
      public string FollowUpEmailAddress { get; set; }
    }
    Invoice invoice = new Invoice
    {
      Company = "Acme Ltd.",
      Amount = 50.0m,
      Paid = false,
      FollowUpDays = 30,
      FollowUpEmailAddress = string.Empty,
      PaidDate = null
    };
     
    string included = JsonConvert.SerializeObject(invoice,
      Formatting.Indented,
      new JsonSerializerSettings { });
     
    // {
    //   "Company": "Acme Ltd.",
    //   "Amount": 50.0,
    //   "Paid": false,
    //   "PaidDate": null,
    //   "FollowUpDays": 30,
    //   "FollowUpEmailAddress": ""
    // }
     
    string ignored = JsonConvert.SerializeObject(invoice,
      Formatting.Indented,
      new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
     
    // {
    //   "Company": "Acme Ltd.",
    //   "Amount": 50.0
    // }
