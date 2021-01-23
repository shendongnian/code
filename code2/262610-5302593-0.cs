    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable 
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            SqlConnection cn = new SqlConnection("CONNECTIONINFO HERE");
            SqlCommand cmd = new SqlCommand("SELECT * FROM test WHERE id=" + request.QueryString["id"], cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //check to see if image was found
            {
                response.ContentType = dr["fileType"].ToString();
                response.BinaryWrite((byte[])dr["imagesmall"]);
            }
            cn.Close();
        }
    }
