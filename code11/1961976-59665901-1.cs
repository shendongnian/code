SELECT c.SurveyCustomerId, MAX( /* THE MAX YOU WANT TO GET */)
FROM dbo.Customer c
 LEFT JOIN dbo.SurveyCustomers sc ON sc.SurveyCustomerId = A.SurveyCustomerId
GROUP BY c.SurveyCustomerId
WHERE c.IsActive = 1 AND c.STATUS = 1 /*AND OTHER CONDITIONS */;
Further reading on GROUP BY clasue:
https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql?view=sql-server-ver15
Update: Sorry missed the LINQ part: You should can do something like this:
public class SurveyCustomer
    {
        public int SurveyCustomerId { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
    public class Survey
    {
        public int SurveyId { get; set; }
    }
    public class SurveyCustomerReadModel
    {
        public int SurveyCustomerId { get; set; }
        public int LastSurveyId { get; set; }
    }
    public class SurveyCustomerRepository
    {
        public List<SurveyCustomer> SurveyCustomers { get; set; }
        public IEnumerable<SurveyCustomerReadModel> GetSurveyCustomerReadModel()
        {
            return this.SurveyCustomers
                .Select(sc => new SurveyCustomerReadModel
                {
                    SurveyCustomerId = sc.SurveyCustomerId,
                    LastSurveyId = sc.Surveys.Max(/* SOME CRITERIA FOR DEFINING THE MAX*/).SurveyId
                });
        }
    }
Regards!
