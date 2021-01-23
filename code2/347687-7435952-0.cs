    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    using System.Xml.Serialization;
    using System.IO;
    
    namespace delete4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Load();
            }
    
            void Load()
            {
                var stream = new FileStream("c:\\pj\\data.txt", FileMode.Open);
    
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "string";
                xRoot.IsNullable = true;
                xRoot.Namespace = "http://schemas.microsoft.com/2003/10/Serialization/";
    
                XmlSerializer s = new XmlSerializer(typeof(sstring), xRoot);
    
                var o = s.Deserialize(stream) as sstring;  // o is your loaded object 
    
                stream.Close();
            }
    
            [ XmlRoot("string"), XmlType("string")]
            public class sstring
            {
                public Catalog catalog;
            }
    
            public class Catalog
            {     
                public Dataset dataset;
            }
    
            public class Dataset
            {
                [XmlAttribute("name")]
                public string Name;
                [XmlAttribute("id")]
                public string ID;
                [XmlAttribute("description")]
                public string Description;
            }
        }
    }
