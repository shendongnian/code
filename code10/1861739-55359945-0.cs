    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication106
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataSet ds = new DataSet("Code_Serial_No");
                DataTable dtCode = new DataTable("Code");
                ds.Tables.Add(dtCode);
                dtCode.Columns.Add("Code", typeof(string));
                dtCode.Columns.Add("Qty", typeof(int));
                dtCode.Rows.Add(new object[] { "A001", 3});
                DataTable dtSerialNo = new DataTable("Serial_No");
                ds.Tables.Add(dtSerialNo);
                dtSerialNo.Columns.Add("Code", typeof(string));
                dtSerialNo.Columns.Add("SerialNo", typeof(string));
                dtSerialNo.Rows.Add(new object[] { "A001", "S01" });
                dtSerialNo.Rows.Add(new object[] { "A001", "S02" });
                dtSerialNo.Rows.Add(new object[] { "A001", "S03" });
                string xml = "<Items></Items>";
                XDocument doc = XDocument.Parse(xml);
                XElement items = doc.Root;
                items.Add(new XElement("Code", ds.Tables["Code"].Rows[0]["Code"]));
                items.Add(new XElement("Qty", ds.Tables["Code"].Rows[0]["Qty"]));
                XElement list = new XElement("SerialNoList");
                items.Add(list);
                foreach (DataRow row in ds.Tables["Serial_No"].AsEnumerable())
                {
                    list.Add(new XElement("SerialNo", row.Field<string>("SerialNo")));
                }
                doc.Save(FILENAME);
            }
     
        }
    }
