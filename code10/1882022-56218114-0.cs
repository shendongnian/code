    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication3
    {
        class Program1
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(LoanProduct));
                LoanProduct loanProduct = (LoanProduct)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "LoanProduct", Namespace = "")]
        public class LoanProduct
        {
            [XmlElement("Program", Namespace = "")]
            public List<Program> programs { get; set; }
        }
        [XmlRoot(ElementName = "Program", Namespace = "")]
        public class Program
        {
            public int ProgramID { get; set; }
            public string Name { get; set; }
            public decimal InterestRate { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
