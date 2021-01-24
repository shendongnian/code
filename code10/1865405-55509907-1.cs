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
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("device", typeof(string));
                dt.Columns.Add("model", typeof(string));
                dt.Columns.Add("serial number", typeof(string));
                dt.Columns.Add("cal site", typeof(string));
                dt.Columns.Add("cal date", typeof(DateTime));
                dt.Columns.Add("unit", typeof(string));
                dt.Columns.Add("temperature", typeof(int));
                dt.Columns.Add("fw version", typeof(string));
                dt.Columns.Add("system", typeof(string));
                dt.Columns.Add("channel", typeof(string));
                dt.Columns.Add("test plan", typeof(string));
                dt.Columns.Add("user", typeof(string));
                dt.Columns.Add("site", typeof(string));
                dt.Columns.Add("site address", typeof(string));
                dt.Columns.Add("work order", typeof(string));
                dt.Columns.Add("guid", typeof(string));
                dt.Columns.Add("comment", typeof(string));
                dt.Columns.Add("test date", typeof(DateTime));
                dt.Columns.Add("test start time", typeof(DateTime));
                dt.Columns.Add("test series", typeof(string));
                dt.Columns.Add("status", typeof(int));
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XElement header = root.Element("Header");
                string device = (string)header.Element("device");
                string model = (string)header.Element("model");
                string sn = (string)header.Element("serialNumber");
                string calSite = (string)header.Element("calSite");
                DateTime calDate = (DateTime)header.Element("calDate");
                string unit = (string)header.Element("temperature").Element("unit");
                int temperature = (int)header.Element("temperature").Element("value");
                string fwVersion = (string)header.Element("fwVersion");
                string system = (string)header.Element("system");
                string channel = (string)header.Element("channel");
                string testPlan = (string)header.Element("testPlan");
                string user = (string)header.Element("user");
                string site = (string)header.Element("site");
                string siteAddr = (string)header.Element("siteAddr");
                string workOrder = (string)header.Element("workOrder");
                string guid = (string)header.Element("guid");
                string comment = (string)header.Element("comment");
                DateTime testDate = (DateTime)header.Element("testDate");
                TimeSpan testTime = DateTime.ParseExact((string)header.Element("testTime"), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).TimeOfDay;
                testDate = testDate.Add(testTime);
                DateTime testStartTime = (DateTime)header.Element("testStartTime");
                string testSeries = (string)header.Element("testSeries");
                int status = (int)header.Element("status");
                dt.Rows.Add(new object[] {
                    device, model, sn, calSite, calDate, unit, temperature, fwVersion, system,
                    channel, testPlan, user, site, siteAddr, workOrder, guid, comment, testDate, testStartTime, testSeries, status
                });
                dataGridView1.DataSource = dt;
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Type", typeof(string));
                dt2.Columns.Add("cID", typeof(int));
                dt2.Columns.Add("mID", typeof(int));
                dt2.Columns.Add("lID", typeof(int));
                dt2.Columns.Add("Unit", typeof(int));
                dt2.Columns.Add("Sto", typeof(int));
                dt2.Columns.Add("Val", typeof(decimal));
                XElement data = root.Descendants("Data").FirstOrDefault();
                foreach(XElement ch in data.Elements("CH"))
                {
                    int cID = (int)ch.Attribute("cID");
                    foreach(XElement meas in ch.Descendants("Meas"))
                    {
                        int mID = (int)meas.Attribute("mID");
                        int lID = (int)meas.Attribute("lID");
                        int dataUnit = (int)meas.Attribute("Unit");
                        int sto = (int)meas.Attribute("Sto");
                        decimal? val = (string)meas.Attribute("Val") == string.Empty ? null : (decimal?)meas.Attribute("Val") ;
                        dt2.Rows.Add(new object[] { "Meas",cID, mID, lID, dataUnit, sto, val });
                    }
                    XElement subData = ch.Descendants("Data").FirstOrDefault();
                    if (subData != null)
                    {
                        foreach (XElement mList in subData.Descendants("mList"))
                        {
                            int mID = (int)mList.Attribute("mID");
                            int lID = (int)mList.Attribute("lID");
                            int dataUnit = (int)mList.Attribute("Unit");
                            int sto = (int)mList.Attribute("Sto");
                            string val = (string)mList.Attribute("Val");
                            decimal? numVal = null;
                            switch (val)
                            {
                                case "True" :
                                    numVal = 1;
                                    break;
                                case "False":
                                    numVal = 0;
                                    break;
                                default:
                                    numVal = val ==  null ? null : val == string.Empty ? null : (decimal?)decimal.Parse(val);
                                    break;
                            }
                            dt2.Rows.Add(new object[] { "Mlist", cID, mID, lID, dataUnit, sto, numVal  });
                        }
                    }
                    
                }
                dataGridView2.DataSource = dt2;
            }
        }
    }
