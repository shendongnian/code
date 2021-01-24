    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                CultureInfo culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                culture.NumberFormat.NumberDecimalSeparator = ",";
                culture.NumberFormat.NumberGroupSeparator = ".";
                XmlReader reader = XmlReader.Create(FILENAME);
                List<Block> blocks = new List<Block>();
                while (!reader.EOF)
                {
                    if (reader.Name != "block")
                    {
                        reader.ReadToFollowing("block");
                    }
                    if (!reader.EOF)
                    {
                        Block newBlock = new Block();
                        blocks.Add(newBlock);
                        XElement xBlock = (XElement)XElement.ReadFrom(reader);
                        newBlock.name = (string)xBlock.Attribute("name");
                        XElement drop = xBlock.Element("drop");
                        if (drop != null)
                        {
                            object count = drop.Attribute("count");
                            newBlock.count = (count == null)? null : (decimal?)decimal.Parse((string)count, culture);
                        }
                    }
                }
            }
            public class Block
            {
                public string name { get; set; }
                public decimal? count { get; set; }
            }
        }
    }
