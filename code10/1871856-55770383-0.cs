    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using System.Data.SqlClient;
    
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
               
                string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(str );
                SqlCommand cmd = new SqlCommand("sproc_tblRooms_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoomNo", SqlDbType.VarChar).Value = txttitle.Text);
                cmd.Parameters.Add("@Occupied ", SqlDbType.VarChar).Value = Occupied.SelectedValue.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "Room has been Updated Successfully";
            }
            catch (Exception)
            { }
        }
    }
