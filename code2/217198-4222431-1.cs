    using System.IO;
    using System.Xml.Serialization;
    [XmlType("Template")]
    public class EmployerInfo
    {
        [XmlArray("Employer"), XmlArrayItem("Value")]
        public string[] _employerName;
    
        [XmlArray("Designation"), XmlArrayItem("Value")]
        public string[] _designation;
    
        [XmlElement("Duration")]
        public string _duration;
    }
    public class Output
    {
        public EmployerInfo Template { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            XmlSerializer serial = new XmlSerializer(typeof(Output));
            using (var reader = new StringReader(@"<Output>
        <Template recordID=""12"">
            <Employer type=""String"">
                <Value>Google</Value>
                <Value>GigaSoft inc.</Value>
            </Employer>
            <Designation  type=""String"">
                <Value>Google</Value>
            </Designation>
            <Duration  type=""String"" />
        </Template>
    </Output>"))
            {
                EmployerInfo fooBar = ((Output)serial.Deserialize(reader)).Template;
            }
        }
    }
