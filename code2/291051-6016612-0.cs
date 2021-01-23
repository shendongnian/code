    <%@ WebHandler Language="C#" Class="Handler2" %>
    
    using System;
    using System.Web;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    
    
    public class Handler2 : IHttpHandler {
    
    
        public void ProcessRequest(HttpContext context)
        {
    
            if (context.Request.QueryString["pid"] != null)
            {
                string ID = context.Request.QueryString["pid"].ToString();
    
                if (dt.Rows.Count > 0)
                {
                    int pid = Convert.ToInt32(ID);
                    SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
                    myConnection.Open();
                    //int i = Convert.ToInt32(context.Request.QueryString["id"]);
                    string sql = "Select BackGroundImage from Wall_BackgrndImg_Master where FK_Company_Master=@ImageId";
                    SqlCommand cmd = new SqlCommand(sql, myConnection);
                    cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = pid;
                    cmd.Prepare();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    try
                    {
                        context.Response.ContentType = "jpg";
                        context.Response.BinaryWrite((byte[])dr["BackGroundImage"]);
                        dr.Close();
                        myConnection.Close();
                    }
                    catch
                    {
    
                    }
                }
            }
    
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
