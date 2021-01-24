    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=(localdb)\v11.0;Integrated Security=true;AttachDbFileName=C:\\Users\\MySelf\\Documents\\Visual Studio 2017\\Projects\\TestSQL\\TestSQL\\App_Data\\Database.mdf;");
        }
    }
