    [WebService(Namespace = "http://site.com/service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class contact_service : System.Web.Services.WebService
    {
    
        [WebMethod]
        public string getDBMessages()
        {
            try
            {
     if (MyConnection.State == System.Data.ConnectionState.Open)
            {
                MyConnection.Close();
            }
            MyConnection.Open();
            OdbcCommand cmd = new OdbcCommand("Select message from messages where name=?", MyConnection);
            cmd.Parameters.Add("@email", OdbcType.VarChar, 255).Value = "human";
            OdbcDataReader dr = cmd.ExecuteReader();
            ArrayList values = new ArrayList();
            while (dr.Read())
            {
                string messagev = dr[0].ToString();
            }
            MyConnection.Close();
    return messagev;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
