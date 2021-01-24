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
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                string xml = File.ReadAllText(FILENAME);
                //textBox1.Text = xml;
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.Descendants().Where(x => x.Name.LocalName == "produktLeczniczy").FirstOrDefault().GetDefaultNamespace();
                List<HeaderResult> results = root.Descendants(ns + "produktLeczniczy").Select(x => new HeaderResult()
                {
                    moc = (string)x.Attribute("moc"),
                    nazwaPowszechnieStosowana = (string)x.Attribute("nazwaPowszechnieStosowana"),
                    rodzajPreparatu = (string)x.Attribute("rodzajPreparatu"),
                    nazwaProduktu = (string)x.Attribute("nazwaProduktu"),
                    substancjaCzynna = x.Descendants(ns + "substancjaCzynna").Select(y => (string)y).ToArray(),
                    lines = x.Descendants(ns + "opakowanie").Select(y => new LinesResult()
                    {
                        id = (int)y.Attribute("id"),
                        kodEAN = (string)y.Attribute("kodEAN"),
                        jednostkaWielkosci = (string)y.Attribute("jednostkaWielkosci"),
                        wielkosc = (string)y.Attribute("wielkosc"),
                    }).ToList()
                }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("moc", typeof(string));
                dt.Columns.Add("nazwaPowszechnieStosowana", typeof(string));
                dt.Columns.Add("rodzajPreparatu", typeof(string));
                dt.Columns.Add("nazwaProduktu", typeof(string));
                dt.Columns.Add("substancjaCzynna", typeof(string));
                dt.Columns.Add("kodEAN", typeof(string));
                dt.Columns.Add("jednostkaWielkosci", typeof(string));
                dt.Columns.Add("wielkosc", typeof(string));
                foreach (HeaderResult result in results)
                {
                    foreach (LinesResult line in result.lines)
                    {
                        dt.Rows.Add(new object[] {
                            line.id,
                            result.moc,
                            result.nazwaPowszechnieStosowana,
                            result.rodzajPreparatu,
                            result.nazwaProduktu,
                            string.Join(",",result.substancjaCzynna),
                            line.kodEAN,
                            line.jednostkaWielkosci,
                            line.wielkosc
                        });
                    }
                }
                dataGridView1.DataSource = dt;
            }
            public class HeaderResult
            {
                public string moc { get; set; }
                public string nazwaPowszechnieStosowana { get; set; }
                public string rodzajPreparatu { get; set; }
                public string nazwaProduktu { get; set; }
                public string[] substancjaCzynna { get; set; }
                public List<LinesResult> lines { get; set; }
            }
            public class LinesResult
            {
                public int id { get; set; }
                public string kodEAN { get; set; }
                public string jednostkaWielkosci { get; set; }
                public string wielkosc { get; set; }
            }
        }
    }
