    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("SERVICE", typeof(string));
                dt.Columns.Add("SITENAME", typeof(string));
                dt.Columns.Add("NODENAME", typeof(string));
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED WAN", "CAPITAL GATE-ADNEC LEANING TOWER", "capitalgatetwrill-ra" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED WAN", "2020 BLDG", "dxbcontactcentreill-rb" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED WAN", "2020 BLDG", "dxbcontactcentreill-ra" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED WAN", "CAPITAL GATE-ADNEC LEANING TOWER", "capitalgatetwrill-rb" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED LAN", "CAPITAL GATE-ADNEC LEANING TOWER", "capitalgatetwrill-ra" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED LAN", "2020 BLDG", "dxbcontactcentreill-rb" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED LAN", "2020 BLDG", "dxbcontactcentreill-ra" });
                dt.Rows.Add(new object[] { "27883481", "EAGLE HILLS PROPERTIES", "MANAGED LAN", "CAPITAL GATE-ADNEC LEANING TOWER", "capitalgatetwrill-rb" });
                dt.Rows.Add(new object[] { "27883", "EAGLE DRILLS PROPERTIES", "MANAGED WAN", "CAPITAL GATE-ADNEC LEANING TOWER", "capitalgatetwrill-ra" });
                dt.Rows.Add(new object[] { "27883", "EAGLE DRILLS PROPERTIES", "MANAGED WAN", "2020 BLDG", "dxbcontactcentreill-rb" });
                dt.Rows.Add(new object[] { "27883", "EAGLE DRILLS PROPERTIES", "MANAGED WAN", "2020 BLDG", "dxbcontactcentreill-ra" });
                dt.Rows.Add(new object[] { "27883", "EAGLE DRILLS PROPERTIES", "MANAGED WAN", "CAPITAL GATE-ADNEC LEANING TOWER", "capitalgatetwrill-rb" });
                dt = dt.AsEnumerable()
                    .OrderBy(x => x.Field<string>("ID"))
                    .ThenBy(x => x.Field<string>("NAME"))
                    .ThenBy(x => x.Field<string>("SERVICE"))
                    .ThenBy(x => x.Field<string>("SITENAME"))
                    .ThenBy(x => x.Field<string>("NODENAME"))
                    .CopyToDataTable();
                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><AllSites></AllSites>";
                XDocument doc = XDocument.Parse(xml);
                XElement allSites = doc.Root;
                foreach (var idGroup in dt.AsEnumerable().GroupBy(x => x.Field<string>("ID")))
                {
                    XElement siteNode = new XElement("SITE_NODE");
                    allSites.Add(siteNode);
                    siteNode.Add(new XElement("ID", idGroup.Key));
                    siteNode.Add(new XElement("NAME", idGroup.First().Field<string>("NAME")));
                    XElement partyServices = new XElement("PARTY_SERVICES");
                    siteNode.Add(partyServices);
                    partyServices.Add(new XElement("SERVICE_NAME", idGroup.First().Field<string>("SERVICE")));
                    foreach (var serviceSite in idGroup.GroupBy(x => x.Field<string>("SITENAME")))
                    {
                        XElement serviceSites = new XElement("SERVICE_SITES");
                        partyServices.Add(serviceSites);
                        serviceSites.Add(new XElement("SITE_NAME", serviceSite.Key));
                        XElement siteNodes = new XElement("SITE_NODES");
                        serviceSites.Add(siteNodes);
                        string[] nodeNames = serviceSite.Select(x => x.Field<string>("NODENAME")).Distinct().ToArray();
                        foreach (string nodeName in nodeNames)
                        {
                            siteNodes.Add(new XElement("NODE_NAME", nodeName));
                        }
                    }
                }
                doc.Save(FILENAME);
            }
        }
    }
