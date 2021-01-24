    using System;
    using System.Data;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
    	    {
    		    string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
        <DATAPACKET Version=""2.0"">
    	    <METADATA>
    		    <FIELDS>
    			    <FIELD attrname=""CompanyID"" fieldtype=""string"" WIDTH=""10""/>
    			    <FIELD attrname=""Description"" fieldtype=""string"" WIDTH=""40""/>
    		    </FIELDS>
    		    <PARAMS/>
    	    </METADATA>
    	    <ROWDATA>
    		    <ROW CompanyID=""CC"" Description=""Contoso""/>
    	    </ROWDATA>
        </DATAPACKET>
        ";
                XmlReader reader = XmlReader.Create(new StringReader(xml));
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader, XmlReadMode.InferTypedSchema);
                var rowTable = dataSet.Tables["ROW"];
                var newRow = rowTable.NewRow();
                newRow["CompanyID"] = "APPL";
                newRow["Description"] = "Apple";
                rowTable.Rows.Add(newRow);
                Console.WriteLine(dataSet.GetXml());
                
                
                XDocument doc = XDocument.Parse(xml);
                DataTable rowTable2 = new DataTable("Table1");
                DataRow newRow2 = null;
                foreach (XElement field in doc.Descendants("FIELD"))
                {
                    string t = (string)field.Attribute("fieldtype");
                    Type _type = null;
                    switch (t)
                    {
                        case "string" :
                            _type = typeof(string);
                            break;
                    }
                   
                    rowTable2.Columns.Add((string)field.Attribute("attrname"), _type);
                }
                foreach (XElement row in doc.Descendants("ROW"))
                {
                    newRow = rowTable2.Rows.Add();
                    foreach (XAttribute attribute in row.Attributes())
                    {
                        newRow[attribute.Name.LocalName] = (string)attribute;
                    }
                }
    		    newRow = rowTable2.Rows.Add();
    		    newRow["CompanyID"] = "APPL";
    		    newRow["Description"] = "Apple";
                DataSet ds = new DataSet();
                ds.Tables.Add(rowTable2);
    		    Console.WriteLine(ds.GetXml());
    	    }
        }
    }
