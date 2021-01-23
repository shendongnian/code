    public class QueryService : DataService<Complaint_Entities>
    {
        protected override Complaint_Entities CreateDataSource()
        {
            var culture = HttpContext.Current.Request.Headers["Culture"];
            string connectionStringName = string.Format("name=Complaint_Entities_{0}", culture);
            return new Complaint_Entities(connectionStringName);
        }
    }
