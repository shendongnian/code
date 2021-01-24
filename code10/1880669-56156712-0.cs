    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string response = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(response);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                DataTable dt = new DataTable();
                dt.Columns.Add("entityID", typeof(string));
                dt.Columns.Add("nameCount", typeof(int));
                dt.Columns.Add("numberCount", typeof(int));
                dt.Columns.Add("addressCount", typeof(int));
                dt.Columns.Add("emailCount", typeof(int));
                dt.Columns.Add("attributeCount", typeof(int));
                dt.Columns.Add("accountCount", typeof(int));
                dt.Columns.Add("roleAlertCount", typeof(int));
                dt.Columns.Add("relationshipCount", typeof(int));
                dt.Columns.Add("eventAlertCount", typeof(int));
                dt.Columns.Add("bestName_internalID", typeof(int));
                dt.Columns.Add("bestName_externalID", typeof(string));
                dt.Columns.Add("bestName_dataSourceCode", typeof(string));
                dt.Columns.Add("bestName_externalReference", typeof(string));
                dt.Columns.Add("bestName_timestamp", typeof(DateTime));
                dt.Columns.Add("bestName_lastModifiedTimestamp", typeof(DateTime));
                dt.Columns.Add("bestName_nameID", typeof(int));
                dt.Columns.Add("bestName_nameTypeCode", typeof(string));
                dt.Columns.Add("bestName_givenName", typeof(string));
                dt.Columns.Add("bestName_surname", typeof(string));
                dt.Columns.Add("bestName_culture", typeof(string));
                List<XElement> entitySummaries = root.Descendants(ns + "entitySummaries").ToList();
                foreach (XElement entitySummary in entitySummaries)
                {
                    DataRow newRow = dt.Rows.Add();
                    string entityID = (string)entitySummary.Element(ns + "entityID");
                    int nameCount = (int)entitySummary.Element(ns + "nameCount");
                    int numberCount = (int)entitySummary.Element(ns + "numberCount");
                    int addressCount = (int)entitySummary.Element(ns + "addressCount");
                    int emailCount = (int)entitySummary.Element(ns + "emailCount");
                    int attributeCount = (int)entitySummary.Element(ns + "attributeCount");
                    int accountCount = (int)entitySummary.Element(ns + "accountCount");
                    int roleAlertCount = (int)entitySummary.Element(ns + "roleAlertCount");
                    int relationshipCount = (int)entitySummary.Element(ns + "relationshipCount");
                    int eventAlertCount = (int)entitySummary.Element(ns + "eventAlertCount");
                    XElement bestName = entitySummary.Element(ns + "bestName");
                    int internalID = (int)bestName.Descendants(ns + "internalID").FirstOrDefault();
                    string externalID = (string)bestName.Descendants(ns + "externalID").FirstOrDefault();
                    string dataSourceCode = (string)bestName.Descendants(ns + "dataSourceCode").FirstOrDefault();
                    string externalReference = (string)bestName.Descendants(ns + "externalReference").FirstOrDefault();
                    DateTime timestamp = (DateTime)bestName.Element(ns + "timestamp");
                    DateTime lastModifiedTimestamp = (DateTime)bestName.Element(ns + "lastModifiedTimestamp");
                    int nameID = (int)bestName.Element(ns + "nameID");
                    string nameTypeCode = (string)bestName.Element(ns + "nameTypeCode");
                    string givenName = (string)bestName.Element(ns + "givenName");
                    string surname = (string)bestName.Element(ns + "surname");
                    string culture = (string)bestName.Element(ns + "culture");
                     newRow.ItemArray = new object[] {
                        entityID,
                        nameCount,
                        numberCount,
                        addressCount,
                        emailCount,
                        attributeCount,
                        accountCount,
                        roleAlertCount,
                        relationshipCount,
                        eventAlertCount,
     
                        internalID,
                        externalID,
                        dataSourceCode,
                        externalReference,
                        timestamp,
                        lastModifiedTimestamp,
                        nameID,
                        nameTypeCode,
                        givenName,
                        surname,
                        culture
                    };
     
                }//end foreach
                datagridview1.Datasource = dt;
            }
        }
    }
