      class Program
        {
            static void Main(string[] args)
            {
                Job j = new Job();
                j.CompanyID = 2;
                j.ID = 1;
                j.Description = "Must be willing to relocate to Nebraska.";
                j.HoursPerWeek = 90;
                j.JobStatus = 1;
                j.JobType = 3;
                j.Location = "NY";
                j.Title = "Application Engineer for Gooooogle Plus";
    
                //Saving the object serialized.
                j.SerializeToXML("MyJob.xml");
    
                //deserialize the saved job into a new instance
                Job j2 = Job.DeserializeToJob("MyJob.xml");
            }
        }
