    public class AccountDetails
    {
      public string FName { get; set; }
      public string LName { get; set; }
      public string Ssn { get; set; }
      public string Dob { get; set; }
      public string Custid { get; set; }
    }
    public IEnumerable<AccountDetails> getCustDetails(string customerId)
    {
        //Pulls customer information for selected customer
        var doc = XDocument.Load("Portfolio.xml");
        var custRecords = from account in doc.Descendants("acct")
                         let acct = account.Element("acct")
                         where (string)account.Attribute("custid").Value == customerId
                         select new AccountDetails
                         {
                             Fname = (string)account.Attribute("fname").Value,
                             Lname = (string)account.Attribute("lname").Value,
                             Ssn = (string)account.Attribute("ssn").Value,
                             Dob = (string)account.Attribute("dob").Value,
                             Custid = (string)account.Attribute("custid").Value
                         };
        return custRecords;
    }
