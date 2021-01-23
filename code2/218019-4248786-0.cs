    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace GrabAndParseXml
    {
        internal class AttrNameAndValue
        {
            public string AttrName { get; set; }
            public string AttrValue { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // grab *ALL* the "XmlContent" columns from your database table
                List<string> xmlContent = GrabXmlStringsFromDatabase();
    
                // parse *ALL* your xml strings into a list of attribute name/values
                List<AttrNameAndValue> attributeNamesAndValues = ParseForAttributeNamesAndValues(xmlContent);
    
                // you can now easily bind this list of attribute names and values to a ListView, a GridView - whatever - try it!
            }
    
            private static List<string> GrabXmlStringsFromDatabase()
            {
                List<string> results = new List<string>();
    
                // connection string - adapt to **YOUR SETUP** !
                string connection = "server=(local);database=test;integrated security=SSPI";
    
                // Query to get the XmlContent columns - I would **ALWAYS** recommend to have a WHERE clause 
                // to limit the number of rows returned from the query - up to you....
                string query = "SELECT XmlContent FROM dbo.TestXml WHERE 1=1";
    
                // set up connection and command for data retrieval
                using(SqlConnection _con = new SqlConnection(connection))
                using (SqlCommand _cmd = new SqlCommand(query, _con))
                {
                    _con.Open();
                    
                    // use a SqlDataReader to loop over the results
                    using(SqlDataReader rdr = _cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            // stick all XML strings into resulting list
                            results.Add(rdr.GetString(0));
                        }
    
                        rdr.Close();
                    }
    
                    _con.Close();
                }
    
                return results;
            }
    
            private static List<AttrNameAndValue> ParseForAttributeNamesAndValues(List<string> xmlContents)
            {
                // create resulting list of "AttrNameAndValue" objects
                List<AttrNameAndValue> attributeNamesAndValues = new List<AttrNameAndValue>();
    
                // loop over all XML strings retrieved from the database
                foreach (string xmlContent in xmlContents)
                {
                    // parse into an XDocument (Linq-to-XML)
                    XDocument xmlDoc = XDocument.Parse(xmlContent);
    
                    // find **ALL** attribute nodes
                    var nodeAttrs = xmlDoc.Descendants().Select(x => x.Attributes());
    
                    // loop over **ALL** atributes in each attribute node
                    foreach (var attrs in nodeAttrs)
                    {
                        foreach (var attr in attrs)
                        {
                            // stick name and value into the resulting list
                            attributeNamesAndValues.Add(new AttrNameAndValue { AttrName = attr.Name.LocalName, AttrValue = attr.Value });
                        }
                    }
                }
    
                return attributeNamesAndValues;
            }
        }
    }
