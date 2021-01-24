        public class DatabaseHandler
        {
        public DatabaseHandler()
        {
        }
        public List<T> Get<T>(string field = "id", string oper = ">", string input = "0") where T : BaseDataModel
        {
            List<T> list = new List<T>();
            DataSet ds = null;
            using (var conn = Connection())
            {
                string query = string.Format("SELECT * FROM {0} WHERE {1} {2} {3}", typeof(T).Name.ToLower(), field, oper, input);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    ds = new DataSet();
                    adapter.Fill(ds);
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    object obj = Activator.CreateInstance(typeof(T));
                    foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                    {
                        if (propertyInfo.CanWrite && propertyInfo.CanRead)
                        {
                            string fieldName = propertyInfo.CustomAttributes.ElementAt(0).ConstructorArguments[0].Value.ToString();
                            if (fieldName == null) continue;
                            propertyInfo.SetValue(obj, row.Field<dynamic>(fieldName));
                        }
                    }
                    list.Add(obj as T);
                }
            }
            return list;
        }
        private MySqlConnection Connection()
        {
            return new MySqlConnection("server=localhost;database=trainingsschema;uid=trainingsschema;pwd=password;");
        }
        }
