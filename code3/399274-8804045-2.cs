    public class XMLJobsDAL
    {
        XDocument JobDoc
        {
            get { return XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Job.xml")); }
        }
        public List<Job> GetJobs()
        {
            var results = from job in JobDoc.Descendants("Job")
                          select new Job
            {
                Id = (int)job.Element("Id"),
                CompanyId = (int)job.Element("CompanyId"),
                Description = (string)job.Element("Description"),
                HoursPerWeek = (int)job.Element("HoursPerWeek"),
                Title = (string) job.Element("Title")
            }
            return results.ToList();
        }
        public Job GetJob(int id)
        {
            var result = from job in JobDoc.Descendants("Job")
                          where (int)job.Element("Id") == id
                          select new Job
            {
                Id = (int)job.Element("Id"),
                CompanyId = (int)job.Element("CompanyId"),
                Description = (string)job.Element("Description"),
                HoursPerWeek = (int)job.Element("HoursPerWeek"),
                Title = (string) job.Element("Title")
            }
            return result.SingleOrDefault();
        }
    }
