    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace WindowsFormsApplication45
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.Descendants().Where(x => x.Name.LocalName == "ZdListGetHeaderResult").FirstOrDefault().GetDefaultNamespace();
                List<HeaderResult> results = root.Descendants(ns + "ZdListGetHeaderResult").Select(x => new HeaderResult()
                {
                    DocId = (int)x.Element(ns + "DocId"),
                    DocNo = (string)x.Element(ns + "DocNo"),
                    DateDoc = (DateTime)x.Element(ns + "DateDoc"),
                    DocStatus = (string)x.Element(ns + "DocStatus"),
                    DocAddressDelivery = (string)x.Element(ns + "DocAddressDelivery"),
                    DocWarehouse = (string)x.Element(ns + "DocWarehouse"),
                    DateRealizationPlanned = (DateTime)x.Element(ns + "DateRealizationPlanned"),
                    lines = x.Descendants(ns + "ZdListGetLinesResult").Select(y => new LinesResult()
                    {
                        PositionItem = (int)y.Element(ns + "PositionItem"),
                        MaterialCode = (int)y.Element(ns + "MaterialCode"),
                        MaterialCatalogNumber = (string)y.Element(ns + "MaterialCatalogNumber"),
                        MaterialDescription = (string)y.Element(ns + "MaterialDescription"),
                        Quantity = (decimal)y.Element(ns + "Quantity"),
                        Unit = (string)y.Element(ns + "Unit"),
                    }).ToList()
                }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("DocId", typeof(int));
                dt.Columns.Add("DocINo", typeof(string));
                dt.Columns.Add("DateDoc", typeof(DateTime));
                dt.Columns.Add("DocStatus", typeof(string));
                dt.Columns.Add("DocAddressDelivery", typeof(string));
                dt.Columns.Add("DocWarehouse", typeof(string));
                dt.Columns.Add("DateRealizationPlanned", typeof(DateTime));
                dt.Columns.Add("PositionItem", typeof(int));
                dt.Columns.Add("MaterialCode", typeof(int));
                dt.Columns.Add("MaterialCatalogNumber", typeof(string));
                dt.Columns.Add("MaterialDescription", typeof(string));
                dt.Columns.Add("Quantity", typeof(decimal));
                dt.Columns.Add("Unit", typeof(string));
                foreach (HeaderResult result in results)
                {
                    foreach (LinesResult line in result.lines)
                    {
                        dt.Rows.Add(new object[] {
                            result.DocId,
                            result.DocNo,
                            result.DateDoc,
                            result.DocStatus,
                            result.DocAddressDelivery,
                            result.DocWarehouse,
                            result.DateRealizationPlanned,
                            line.PositionItem,
                            line.MaterialCode,
                            line.MaterialCatalogNumber,
                            line.MaterialDescription,
                            line.Quantity,
                            line.Unit
                        });
                    }
                }
                dataGridView1.DataSource = dt;
                DataTable dt2 = dt.AsEnumerable().Where(x => x.Field<int>("DocId") == 222).CopyToDataTable();
                dataGridView2.DataSource = dt2;
            }
        }
        public class HeaderResult
        {
            public int DocId { get; set; }
            public string DocNo { get; set; }
            public DateTime DateDoc { get; set; }
            public string DocStatus { get; set; }
            public string DocAddressDelivery { get; set; }
            public string DocWarehouse { get; set; }
            public DateTime DateRealizationPlanned { get; set; }
            public List<LinesResult> lines { get; set; }
        }
        public class LinesResult
        {
            public int PositionItem { get; set; }
            public int MaterialCode { get; set; }
            public string MaterialCatalogNumber { get; set; }
            public string MaterialDescription { get; set; }
            public decimal Quantity { get; set; }
            public string Unit { get; set; }
        }
    }
