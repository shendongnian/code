       [WebService(Namespace = "http://babyUnicorns.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    [ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public object dbAccess()
        {
            
            DataTable table = new DataTable("myTable");
            ArrayList arl = new ArrayList();
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localConnectionString"].ConnectionString))
            { 
                using(SqlCommand comm = new SqlCommand("SELECT * FROM VehicleMakes",conn))
                {
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    conn.Close();    
                }            
            }
            foreach(DataRow dRow in table.Rows)
                    {
                        arl.Add(dRow["VehicleMake"]+"  "+dRow["VehicleMakeId"]);    
                    }
            return arl.ToArray();       
        }  
    }
