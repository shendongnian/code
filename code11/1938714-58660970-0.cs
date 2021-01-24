    static void Main(string[] args)
        {
            string strXML = @"<root><Inflection>innerText1</Inflection>
                                    <Inflection>innerText2<Variant>innerText2Variant</Variant></Inflection></root>";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strXML);
            XmlNodeList nodesInflection = xml.SelectNodes("/root/Inflection");
            foreach(XmlNode n in nodesInflection)
            {
                if (n.ChildNodes.Count == 1)
                {
                    Console.WriteLine(n.InnerText);
                    //or 
                    Console.WriteLine(n.ChildNodes[0].InnerText);
                }
                else
                {
                    Console.WriteLine(n.ChildNodes[0].InnerText);
                    XmlNode nodeVariant = n.SelectSingleNode("Variant");
                    //or
                    //XmlNode nodeVariant = n.ChildNodes[1];
                    Console.WriteLine(nodeVariant.InnerText);
                }
            }
            Console.WriteLine("*******press any key");
            Console.ReadKey();
        }
