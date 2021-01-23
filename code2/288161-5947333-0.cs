    namespace LearningASP
    
    { public partial class _Default : System.Web.UI.Page
    
    { protected void Page_Load(object sender, EventArgs e)
    
    {
    
    SqlConnection conn = new SqlConnection("Server=localhost;" + "Database=DB;User ID=aaaa;" + "Password=aaaa");
    
            conn.Open(); 
    **SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = cmd.ExecuteReader();** 
    while (reader.Read()) {             employeesLabel.Text += reader["Name"] + "<br />"; } reader.Close();          conn.Close();      } } }
