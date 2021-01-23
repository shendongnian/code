    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    namespace XMLReader
    {
    /// <summary>
    /// Author: Inocêncio T. de Oliveira
    /// Reader a XML file and put all content into a Dictionary
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //the source of the XML
            XmlTextReader reader = new XmlTextReader("c:\\myxml.xml");
            //dictionary to be filled
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //temporary variable to store the field value
            string field = "";
            int count = 0;
            //reading step thru the XML file
            while (reader.Read())
            {
                XmlNodeType nt = reader.NodeType;
                if (nt == XmlNodeType.Text)
                {
                    //Console.WriteLine(reader.Name.ToString());
                    if (count == 0)
                    {
                        //store temporarily the field value
                        field = reader.Value.ToString();
                        count++;
                    } else if (count == 1)
                    {
                        //add a new entry in dictionary
                        dic.Add(field, reader.Value.ToString());
                        count = 0;
                    }
                }
            }
            //we done, let´s check if datas are OK stored!
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                Console.WriteLine("field [{0}] : value [{1}]", kvp.Key, kvp.Value);
            }
            Console.ReadKey();
        }
    }
    }
