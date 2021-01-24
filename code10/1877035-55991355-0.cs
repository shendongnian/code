    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement client in doc.Descendants("client"))
                {
                    Client newClient = new Client();
                    Client.clients.Add(newClient);
                    newClient.name = (string)client.Element("name");
                    newClient.ssid = (string)client.Element("ssid");
                    newClient.pswd = (string)client.Element("pswd");
                    List<XElement> xAccounts = client.Elements().Where(x => (x.Name.LocalName == "savingsAcc") || (x.Name.LocalName == "regularAcc")).ToList();
                    foreach (XElement xAccount in xAccounts)
                    {
                        Account newAccount = null;
                        switch (xAccount.Name.LocalName)
                        {
                            case "savingsAcc" :
                                newAccount = new SavingsAccount();
                                break;
                            case "regularAcc":
                                newAccount = new RegularAccount();
                                break;
                        }
                        newClient.accounts.Add(newAccount);
                        newAccount.name = (string)xAccount.Element("name");
                        newAccount.accountNumber = (string)xAccount.Element("accountNumber");
                        newAccount.balance = (decimal)xAccount.Element("balance");
                    }
                }
            }
        }
        public class Client
        {
            public static List<Client> clients = new List<Client>();
            public string name { get; set; }
            public string ssid { get; set; }
            public string pswd { get; set; }
            public List<Account> accounts = new List<Account>();
        }
        public class Account
        {
            public string name { get; set; }
            public string accountNumber { get; set; }
            public decimal balance { get; set; }
        }
        public class SavingsAccount : Account 
        {
        }
        public class RegularAccount : Account
        {
        }
    }
