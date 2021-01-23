    using Newtonsoft.Json; //download this
    
    
     [WebMethod]
        public string ReturnData(int IdOfEvent)
        {
    
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionCarpool"]);
    
            DataRow dr = ExecuteDataSet(("SELECT Lat, Lng FROM Users Where UserID=" + IdOfEvent).ToString()).Tables[0].Rows[0];
    
            Mapa prd = new Mapa();
            List<Mapa> lst = new List<Mapa>(); 
    
            prd.Lat = dr["Lat"].ToString();
            prd.Lng = dr["Lng"].ToString();
    
            lst.Add(prd);  
    
         
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(lst.ToArray());
            return strJSON; 
    
    
        }
