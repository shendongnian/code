csharp
public class Example
{
    public class Driver
    {
        public string DriverId { get; set; }
        // .. and the remaining properties
        public XElement ToXElement()
        {
            return new XElement("DriverEntry"
                /* add the remaining properties as XElement's here */);
        }
    }
    public class Submission
    {
        public string SubmissionId { get; set; }
        public string PolicyNumber { get; set; }
        // .. and the remaining properties
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public XElement ToXElement()
        {
            return new XElement("SubmissionEntry",
                /* add the remaining properties as XElement's here */
                new XElement("PolicyDrivers",
                    Drivers.Select(d => d.ToXElement())));
        }
    }
    public static void ConvertToXml()
    {
        string[] lines = File.ReadAllLines(@"H:\SSIS\Source\Intermediate.csv");
        Dictionary<string, Submission> submissions = new Dictionary<string, Submission>();
        foreach (var line in lines)
        {
            var columns = line.Split(',');
            var submissionId = columns[0];
            if (submissions.ContainsKey(submissionId))
            {
                var submission = submissions[submissionId];
                submission.Drivers.Add(new Driver
                {
                    // fill in properties with columns data
                });
            }
            else
            {
                var submission = new Submission
                {
                    // fill in properties with columns data
                };
                submissions[submissionId] = submission;
            }
        }
        XElement xml = new XElement("Submissions", submissions.Values.Select(s => s.ToXElement()));
        xml.Save(@"H:\SSIS\Destination\demo xml.xml");
    }
}
