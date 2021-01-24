    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xmlResponse = File.ReadAllText(FILENAME);
                XDocument xDocument = XDocument.Parse(xmlResponse);
                XElement emsg = xDocument.Descendants().Where(x => x.Name.LocalName == "T_OUTPUT").FirstOrDefault();
                XNamespace ns = emsg.GetDefaultNamespace();
                if (emsg != null)
                {
                    var parsedData =
                    (
                        from e in xDocument.Descendants(ns + "item")
                        select new ProductPipelineTankInventoryEntity
                        {
                            BUKRS = (long)e.Element(ns + "BUKRS"),
                            WERKS = (long)e.Element(ns + "WERKS"),
                            NAME1 = (string)e.Element(ns + "NAME1"),
                            REGIO = (string)e.Element(ns + "REGIO"),
                            MATKL = (string)e.Element(ns + "MATKL"),
                            MATNR = (long)e.Element(ns + "MATNR"),
                            LGORT = (string)e.Element(ns + "LGORT"),
                            GRDIP = (double)e.Element(ns + "GRDIP"),
                            TRNDATE = (DateTime)e.Element(ns + "TRNDATE"),
                            VOL_NATURAL = (double)e.Element(ns + "VOL_NATURAL"),
                            GRDIP_RUN = (double)e.Element(ns + "GRDIP_RUN"),
                            VOL_RUNNING = (double)e.Element(ns + "VOL_RUNNING")
                        }
                    ).ToList();
                }
            }
        }
        public class ProductPipelineTankInventoryEntity
        {
            public long BUKRS { get; set; }
            public long WERKS { get; set; }
            public string NAME1 { get; set; }
            public string REGIO { get; set; }
            public string MATKL { get; set; }
            public long MATNR { get; set; }
            public string LGORT { get; set; }
            public double GRDIP { get; set; }
            public DateTime TRNDATE { get; set; }
            public double VOL_NATURAL { get; set; }
            public double GRDIP_RUN { get; set; }
            public double VOL_RUNNING { get; set; }
        }
    }
 
