    class Program
    {
        public static string[][] ReadCsvDataFromFile()
        {
            //sample, just first row for CSV-data 
            var fakeCSVData = new List<string[]>();
            fakeCSVData.Add(new string[] { "CU00000HGMESEBT8", "Joe", "1", "Sleuth IT", "1", "payment" });
            return fakeCSVData.ToArray();
        }
        static void Main(string[] args)
        {
            var csvData = ReadCsvDataFromFile();
            var doc = new System.Xml.XmlDocument();
            for (var i = 0; i < csvData.Length; i++)
            {
                var csvRowAsArray = csvData[i];
                var recordHeader = doc.CreateElement("CUSTOMERPAYMENTJOURNALHEADERENTITY");
                var jbatchnumTag = doc.CreateNode(XmlNodeType.Element, "JOURNALBATCHNUMBER", "");
                jbatchnumTag.InnerText = csvRowAsArray[0];
                recordHeader.AppendChild(jbatchnumTag);
                var descTag = doc.CreateNode(XmlNodeType.Element, "DESCRIPTION", "");
                //descTag.InnerText = ??
                recordHeader.AppendChild(descTag);
                var jnameTag = doc.CreateNode(XmlNodeType.Element, "JOURNALNAME", "");
                //jnameTag.InnerText = ???
                recordHeader.AppendChild(jnameTag);
                var customerRecord = doc.CreateElement("CUSTOMERPAYMENTJOURNALENTITY");
                var jbatchnumTag2 = doc.CreateNode(XmlNodeType.Element, "JOURNALBATCHNUMBER", "");
                jbatchnumTag2.InnerText = csvRowAsArray[0];
                customerRecord.AppendChild(jbatchnumTag2);
                var lineNumTag = doc.CreateNode(XmlNodeType.Element, "LINENUMBER", "");
                lineNumTag.InnerText = csvRowAsArray[2];
                customerRecord.AppendChild(lineNumTag);
                var accountDisplayTag = doc.CreateNode(XmlNodeType.Element, "ACCOUNTDISPLAYVALUE", "");
                accountDisplayTag.InnerText = csvRowAsArray[3];
                customerRecord.AppendChild(accountDisplayTag);
                var accountTypeTag = doc.CreateNode(XmlNodeType.Element, "ACCOUNTTYPE", "");
                accountTypeTag.InnerText = csvRowAsArray[3];
                customerRecord.AppendChild(accountDisplayTag);
                var bankTransactionTypeTag = doc.CreateNode(XmlNodeType.Element, "BANKTRANSACTIONTYPE", "");
                bankTransactionTypeTag.InnerText = csvRowAsArray[5];
                customerRecord.AppendChild(bankTransactionTypeTag);
                var voucherTag = doc.CreateNode(XmlNodeType.Element, "VOUCHER", "");
                voucherTag.InnerText = csvRowAsArray[1];
                customerRecord.AppendChild(voucherTag);
                recordHeader.AppendChild(customerRecord);
                doc.AppendChild(recordHeader);
            }
            doc.Save(@"test.xml");
        }
    }
}
