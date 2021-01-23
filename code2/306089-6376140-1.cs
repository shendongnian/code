    public Submission GetSubmissionsByID(string x)
    {
    
    
          string viewQuery = "SELECT Submission.SubmissionId, Customer.CustName, Customer.SicNaic, Customer.CustCity, Customer.CustAddress, Customer.CustState, Customer.CustZip, Broker.BroName, Broker.BroCity, Broker.BroAddress, Broker.BroState, Broker.BroZip, Broker.EntityType, Submission.Coverage, Submission.CurrentCoverage, Submission.PrimEx, Submission.Retention, Submission.EffectiveDate, Submission.Commission, Submission.Premium, Submission.Comments FROM Submission INNER JOIN Broker ON Broker.BroId = Submission.BroId INNER JOIN Customer ON Customer.CustId = Submission.CustId WHERE Submission.SubmissionId =" + x;
          ...
