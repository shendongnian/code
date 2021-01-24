    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        
        public class YourClass : System.Web.Services.WebService
        {
        [System.Web.Script.Services.ScriptMethod()]
            [System.Web.Services.WebMethod]
        
            public static List<string> GetListofCountries(string prefixText)
            {
                DataLayer.DAL dl = new DataLayer.DAL();
                string queryfetchconsul = "Select distinct project_name from mis_projects_master where project_name ilike '%" + prefixText + "%' ";
                DataTable dt = dl.executeGetData(queryfetchconsul);
        
                List<string> CountryNames = new List<string>();
        
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CountryNames.Add(dt.Rows[i]["project_name"].ToString());
                }
        
                return CountryNames;
            }
        
            [System.Web.Script.Services.ScriptMethod()]
            [System.Web.Services.WebMethod]
            public static List<string> refrencenumber(string prefixText1)
            {
                DataLayer.DAL dl = new DataLayer.DAL();
                string queryfetchconsul1 = "Select distinct ref_number from mis_project_details where ref_number ilike '%" + prefixText1 + "%' ";
                DataTable dt1 = dl.executeGetData(queryfetchconsul1);
        
                List<string> CountryNames1 = new List<string>();
        
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    CountryNames1.Add(dt1.Rows[i]["ref_number"].ToString());
                }
        
                return CountryNames1;
            }
        
            [System.Web.Script.Services.ScriptMethod()]
            [System.Web.Services.WebMethod]
            public static List<string> invoicenumber(string prefixText2)
            {
                DataLayer.DAL dl = new DataLayer.DAL();
                string queryfetchconsul2 = "Select distinct inv_no from mis_lumpsum_milestones_fin_progress where inv_no ilike '%" + prefixText2 + "%' ";
                DataTable dt2 = dl.executeGetData(queryfetchconsul2);
        
                List<string> CountryNames2 = new List<string>();
        
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                  CountryNames2.Add(dt2.Rows[i]["inv_no"].ToString());
                }
                return CountryNames2;
            }
        
            //webmethod
    
    }
