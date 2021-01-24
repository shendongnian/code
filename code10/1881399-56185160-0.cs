    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                SqlConnection cn = new SqlConnection(@"Data Source=192.168.0.61\newsql;Initial Catalog=AIETraining;User ID=AIETrainingAccount;Password=Training@1234");
    
                cn.Open();
                Response.Write("Connection established");
    
                SqlCommand command = new SqlCommand("Select * from [Gursimran Singh].[publishers]", cn);
    
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { 
                           new DataColumn("pub_id", typeof(int)),
                           new DataColumn("pub_name",typeof(string)),
                           new DataColumn("city",typeof(string)),
                           new DataColumn("state",typeof(string)),
                           new DataColumn("Country",typeof(string))});
    
                SqlDataAdapter sda = new SqlDataAdapter();
    
                using (command)
                {
                    using (sda) 
                    {
                         command.Connection = cn;
                         sda.SelectCommand = command;
    
                         using(dt)
                         {
                              sda.Fill(dt);
    
                              GridView1.DataSource = dt;
                              GridView1.DataBind();
                         }
                    }
                }
    
                cn.Close();
            }
        }
    }
