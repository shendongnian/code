csharp
public class Example
{
    public class Driver
    {
        public string DriverId { get; set; }
        // .. add remaining properties
        public static Driver FromCsv(string[] row)
        {
            return new Driver
            {
                DriverId = row[26],
                // fill remaining driver properties with columns data
            };
        }
        public XElement ToXElement()
        {
            return new XElement("DriverEntry",
                new XElement("DriverID", DriverId)
                /* add remaining properties as XElement's */);
        }
    }
    public class Submission
    {
        public string SubmissionId { get; set; }
        public string PolicyNumber { get; set; }
        // .. add remaining properties
        public List<Driver> PolicyDrivers { get; set; }
        public static Submission FromCsv(string[] row)
        {
            return new Submission
            {
                SubmissionId = row[0],
                PolicyNumber = row[1],
                PolicyDrivers = new List<Driver> { Driver.FromCsv(row) },
                // fill remaining submission properties with columns data
            };
        }
        public XElement ToXElement()
        {
            return new XElement("SubmissionEntry",
                new XElement("SubmissionID", SubmissionId),
                new XElement("PolicyNumber", PolicyNumber),
                /* add remaining properties as XElement's */
                new XElement("PolicyDrivers",
                    PolicyDrivers.Select(d => d.ToXElement())));
        }
    }
    public static void ConvertToXml()
    {
        string[] lines = File.ReadAllLines(@"H:\SSIS\Source\Intermediate.csv");
        Dictionary<string, Submission> submissions = new Dictionary<string, Submission>();
        foreach (var line in lines)
        {
            var row = line.Split(',');
            var submissionId = row[0];
            if (submissions.ContainsKey(submissionId))
            {
                var submission = submissions[submissionId];
                submission.PolicyDrivers.Add(Driver.FromCsv(row));
            }
            else
            {
                submissions[submissionId] = Submission.FromCsv(row);
            }
        }
        XElement xml = new XElement("Submissions", submissions.Values.Select(s => s.ToXElement()));
        xml.Save(@"H:\SSIS\Destination\demo xml.xml");
    }
}
In the example we create `Submission` and `Driver` objects, where a submission can have one or more `PolicyDrivers`. Each submission is stored in a dictionary where the key is the `SubmissionID` - so if there are multiple entries for a single `SubmissionID`, the `PolicyDrivers` will get merged together.
This implies that only `PolicyDrivers` will change in the case of a collision on `SubmissionID`.
