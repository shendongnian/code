    	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Web;
	using System.Web.Services;
	using System.Web.Services.Protocols;
	using System.Xml.Linq;
	using System.Data.SqlClient;
	using System.Web.Script.Services;
	
	
	
	namespace YourProject
	{
	    /// <summary>
	    /// Summary description for WebService
	    /// </summary>
	    // [ScriptService]
	    //[System.Web.Script.Services.ScriptService()]
	    [WebService(Namespace = "http://tempuri.org/")]
	    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	    [ToolboxItem(false)]
	    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	    [System.Web.Script.Services.ScriptService]
	    public class WebService : System.Web.Services.WebService
	    {
	
	        protected void Page_Load(object sender, EventArgs e)	
	        {
	
	        }
	        [WebMethod]
	        public string HelloWorld()
	        {
	            return "Hello World";
	        }
	        [WebMethod]
	        public string[] GetCompletionList(string prefixText)
	        {
	
	            string sql = "Select productname from F_Product Where productname like @prefixText ";
	            SqlDataAdapter da = new SqlDataAdapter(sql, System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
	            da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
	            DataTable dt = new DataTable();
	            da.Fill(dt);
	            string[] items = new string[dt.Rows.Count];
	            int i = 0;
	            foreach (DataRow dr in dt.Rows)
	            {
	                items.SetValue(dr["productname"].ToString(), i);
	                i++;
	            }
	            return items;
	        }
	 }
	}
