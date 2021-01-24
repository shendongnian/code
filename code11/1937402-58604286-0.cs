    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    [XmlRoot("treasury")]
    public class Treasury
    {
        [XmlElement("institutions")]
        public Institutions institutions { get; set; }
    }
    [XmlRoot("institutions")]
    public class Institutions
    {
        [XmlElement("INSTITUTION")]
        public List<Institution> InstitutionList { get; set; }
    }
    public class Institution
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlAttribute("CODE")]
        public string Code;
        [XmlAttribute("INN")]
        public string Inn;
    }
    public class Program
    {
        const string FILENAME = @"c:\temp\test.xml";
        public static void Main(String[] args)
        {
            Program pro = new Program();
            pro.DeserializeObject(FILENAME);
        }
        private void DeserializeObject(string filename)
        {
            Console.WriteLine("Reading with XML Reader");
            XmlSerializer serializer = new XmlSerializer(typeof(Institutions));
            XmlReader reader = XmlReader.Create(FILENAME);
            Treasury treasuryAccounts = new Treasury();
            treasuryAccounts.institutions = (Institutions)serializer.Deserialize(reader);
            reader.Close();
            Console.WriteLine("\n------------------------------------------Institutions---------------------------------------------------------\n");
            foreach (var institition in treasuryAccounts.institutions.InstitutionList)
            {
                Console.Write("Treasury Account Name:" + institition.Name
                      + "\tCODE:" + institition.Code
                      + "\tINN:" + institition.Inn
                      + "\n\n"
              );
            }
            Console.ReadKey();
        }
    }
