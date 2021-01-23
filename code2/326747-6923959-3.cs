    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    
    /// <summary>
    /// Summary description for Connection
    /// </summary>
    public class Connection
    
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter ad;
        SqlCommand cmd;
        SqlDataReader rd;
    	public Connection()
    	{
            // Set Your Database Path Here from C:\user onwords
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\SIROI.COM\Documents\Visual Studio 2008\WebSites\WebSite14\App_Data\ASPNETDB.MDF;Integrated Security=True;User Instance=True";
                   		
    	}
        
        public DataSet filldata(DataSet ds, string query, string tbname)
        {
            try
            {
                con.Open();
                ad = new SqlDataAdapter(query, con);
                ad.Fill(ds, tbname);
                
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public bool ExecuteQuery(string query)
        {
            bool flag = false;
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    flag = true;
                }          
            }
            catch(Exception ex)
            {
    
            }
            finally
            {
                con.Close();
            }
            return flag;
        }
        public SqlDataReader ExecuteReader(string query)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
    
            }
           
            return rd;
        }
    }
