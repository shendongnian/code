    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
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
                        newBlock.count = (int)xBlock.Element("drop").Attribute("count");
                    }
                }
            }
            public class Block
            {
                public string name { get; set; }
                public int count { get; set; }
            }
        }
    }
