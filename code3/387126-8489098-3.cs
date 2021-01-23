    public partial class sms : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        string subject = Request.Params["subject"];
        string message = Request.Params["body-plain"];
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["YOURCONNECTIONSTRING"].ConnectionString))
        {
            cn.Open();
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.Text;
                cm.CommandText = "INSERT INTO SMS (subject, message, DateTime) VALUES (@Subject, @Message, @Dateandtime);";
                cm.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
                cm.Parameters.Add("@Message", SqlDbType.NVarChar).Value = message;
                cm.Parameters.Add("@Dateandtime", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                SqlDataReader dr = cm.ExecuteReader();
                dr.Dispose();
                cm.Dispose();
            }
        }
    }
    }
