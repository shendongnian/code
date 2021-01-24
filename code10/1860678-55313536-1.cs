    public class DataHelper
    {
        public static POModel GetCurrency(string currencyCode)
        {
            //string currencyName = "";
    		var poModel = new POModel();
            SqlConnection con = new SqlConnection(@"Data Source=WEB3\SHAREPOINT;Initial Catalog=WSS_Search_WEB3;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select PO_NUMBER,PO_STATUS from View_1 where PO_HEADER_ID ='" + currencyCode.ToUpper() + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                poModel.currencyName = dr["PO_NUMBER"].ToString();
                poModel.statusName = dr["PO_STATUS"].ToString();
            }
            dr.Close();
            con.Close();
            //return currencyName;
            return poModel;
        }
    }
    
    public class POModel
    {
        public string currencyName { get; set; }
        public string statusName { get; set; }
    }
