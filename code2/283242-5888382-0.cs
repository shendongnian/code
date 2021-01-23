        [OperationContract]
        public List<Languages> LanguageList(string query)
        {
            string nwConn = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            var langList = new List<Languages>();
            using (MySqlConnection conn = new MySqlConnection(nwConn))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr != null)
                        while (dr.Read())
                        {
                            var lang = new Languages
                            {
                                LangID = dr.GetString(0),
                                LangName = " " + dr.GetString(1),
                                LangPath = dr.GetString(2),
                                LangDef = dr.GetString(3)
                            };
                            langList.Add(lang);
                        }
                    return langList;
                }
            }
        }
    [DataContract]
    public class Languages
    {
        [DataMember]
        public string LangID;
        [DataMember]
        public string LangName;
        [DataMember]
        public string LangPath;
        [DataMember]
        public string LangDef;
    }
