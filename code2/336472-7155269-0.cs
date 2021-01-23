    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["productID"] != null)
            {
                try
                {
                    string ProductID = context.Request.QueryString["ProductID"];
                    if (Convert.ToInt32(ProductID) > 0)
                    {
                        const string CONN 
                            = "Initial Catalog=xxx;Data Source=xxx;Integrated Security=SSPI;";
    
                        string selectQuery 
                            = "SELECT Photo FROM dbo.Products WHERE dbo.Products.ProductID=" 
                                + ProductID.ToString();
                        SqlConnection conn = new SqlConnection(CONN);
                        SqlCommand cmd = new SqlCommand(selectQuery, conn);
    
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
    
                        dr.Read();
                        context.Response.BinaryWrite((Byte[])dr[0]);
                        dr.Close();
                        conn.Dispose();
                        // context.Response.End(); 
                        // caused an "Abort thread" error 
                        // - this is correct and is a special exception
                    }
                }
                catch (Exception ex)
                {
                    ErrorReporting.LogError(ex);   
                }
            }
            else
                throw new ArgumentException("No ProductID parameter specified");
        }
    
        public bool IsReusable
        {
            get
            {
                return true; // multiple images otherwise false
            }
        }
    }
