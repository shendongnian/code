     static void Main(string[] args)
        {
            string xmlContent = GrabStringFromDatabase(1);
            List<string> attributeNames = ParseForAttributeNames(xmlContent);
            Console.WriteLine("Your XML attributes are: {0}", string.Join(",", attributeNames.ToArray()));
        }
        private static string GrabStringFromDatabase(int ID)
        {
            string result = string.Empty;
            string connection = "server=(local);database=test;integrated security=SSPI";
            string query = "SELECT XmlContent FROM dbo.TestXml WHERE ID = @ID";
            using(SqlConnection _con = new SqlConnection(connection))
            using (SqlCommand _cmd = new SqlCommand(query, _con))
            {
                _cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                _con.Open();
                result = _cmd.ExecuteScalar().ToString();
                _con.Close();
            }
            return result;
        }
        private static List<string> ParseForAttributeNames(string xmlContent)
        {
            List<string> attributeNames = new List<string>();
            XDocument xmlDoc = XDocument.Parse(xmlContent);
            var nodeAttrs = xmlDoc.Descendants().Select(x => x.Attributes());
            foreach (var attrs in nodeAttrs)
            {
                foreach (var attr in attrs)
                {
                    attributeNames.Add(attr.Name.LocalName);
                }
            }
            return attributeNames;
        }
