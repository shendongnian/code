    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Data;
    namespace ConsoleApplication122
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                dt.Columns.Add("CORE_PATHOLOGY_TOPOGRAPHY_SNOMED_PATHOLOGY", typeof(string));
                dt.Rows.Add(new object[] { "6000"});
                int iRowCounter = 0;
                CoreCorePathologyTypeTopographySNOMEDPathology TopographySNOMEDPathology = new CoreCorePathologyTypeTopographySNOMEDPathology()
                {
                    TopographySNOMEDPathology  = new List<TopographySNOMEDPathology>() {
                        new TopographySNOMEDPathology() {   code = (string)ds.Tables[0].Rows[iRowCounter]["CORE_PATHOLOGY_TOPOGRAPHY_SNOMED_PATHOLOGY"] }
                    }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(CoreCorePathologyTypeTopographySNOMEDPathology));
                serializer.Serialize(writer, TopographySNOMEDPathology);
             }
        }
        [XmlRoot("CoreCorePathologyTypeTopographySNOMEDPathology")]
        [XmlInclude(typeof(CV))]
        public partial class CoreCorePathologyTypeTopographySNOMEDPathology : CV
        {
            [XmlElement("TopographySNOMEDPathology")]
            public List<TopographySNOMEDPathology> TopographySNOMEDPathology { get; set; }
        }
        public class CV
        {
        }
        [XmlRoot("TopographySNOMEDPathology")]
        public class TopographySNOMEDPathology
        {
            public string code { get; set; }
        }
     
     
    }
