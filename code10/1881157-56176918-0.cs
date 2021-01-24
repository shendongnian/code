    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string response = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(response);
                XElement hrDetails = doc.Root;
                HR hr = new HR()
                {
                    employeeLastName = (string)hrDetails.Attribute("EmployeeLastName"),
                    employeeFirstName = (string)hrDetails.Attribute("EmployeeFirstName"),
                    employeeID = (string)hrDetails.Attribute("EmployeeID"),
                    id = (string)hrDetails.Attribute("ID"),
                    organizationCode = (string)hrDetails.Attribute("OrganizationCode"),
                    division = (string)hrDetails.Attribute("Division"),
                    officialPositionTitle = (string)hrDetails.Attribute("OfficialPositionTitle"),
                    occupationalSeries = (string)hrDetails.Attribute("OccupationalSeries"),
                    anualPay = (decimal)hrDetails.Attribute("AnualPay")
                };
                hr.accounts = hrDetails.Elements().Select(x => new Accounts() {
                     name = x.Name.LocalName, accounts = x.Elements().Select(y => new Account() {
                        name = y.Name.LocalName,
                        amount = (decimal)y.Element("Amount"),
                        date = (DateTime)y.Element("Date")
                    }).ToList()
                }).ToList();
            }
        }
        public class HR
        {
            public string employeeLastName { get; set;}
            public string employeeFirstName  { get; set;}
            public string employeeID  { get; set;}
            public string id  { get; set;}
            public string organizationCode  { get; set;}
            public string division  { get; set;}
            public string officialPositionTitle  { get; set;}
            public string occupationalSeries  { get; set;}
            public decimal anualPay  { get; set;}
            public List<Accounts> accounts { get; set; }
        }
        public class Accounts
        {
            public string name { get; set; }
            public List<Account> accounts { get; set; }
        }
        public class Account
        {
            public string name { get; set; }
            public decimal amount { get; set; }
            public DateTime date { get; set; }
        }
        
    }
