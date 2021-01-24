    protected void Page_Load(object sender, EventArgs e)
            {
                string constring = ConfigurationManager.ConnectionStrings["YourConnectionstring"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Yourtable", con);
                con.Close();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                Da.Fill(dt);
                JavaScriptSerializer jsSerializer1 = new JavaScriptSerializer();
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dt.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        childRow.Add(col.ColumnName.Trim(), row[col].ToString().Trim());
                    }
                    parentRow.Add(childRow);
                }
                string jsonString = jsSerializer1.Serialize(parentRow);
                jsonString = Regex.Replace(jsonString, @"\""\\/Date\((-?\d+)\)\\/\""", "$1");
                Response.Write("{\"data\":");
                Response.Write(jsonString);
                Response.Write("");
                Response.Write("");
                Response.Write("}");
            }
