    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.OracleClient;
    using System.Windows.Forms;
    
    public partial class _Default : System.Web.UI.Page 
    {
        private db connection = new db();
        private string[,] errorMessage = 
            { {"Expired", "Unsuccessful", "Incorrect"}, 
            {"Your Logon Session Has Expired", "Invalid Username or Password", 
                "Selected Data Source is not supported within this application"} };
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
    
            foreach (string name in connection.GetDbList())
                ddlDatabase.Items.Add(name);
    
            if (Session["Error"] != null)
                    ErrorMessage();
    
            if (Session["Datasource"] != null)
            {
                ddlDatabase.SelectedValue = Session["Datasource"].ToString();
                Session["Datasource"] = null;
            }
            
        }
    
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string dataSource = ddlDatabase.SelectedValue.ToString();
            string userID = txtUserID.Text;
            string password = txtPassword.Text;
    
            connection = new db(dataSource, userID, password);
    
            if (connection.IsValid())
            {
                try
                {
                    connection.GetConnection().Open();
                    Session["Username"] = userID;
                    Session["Password"] = password;
                    Session["Datasource"] = ddlDatabase.SelectedValue;
                    Response.Clear();
                    Response.Redirect("main.aspx", false);
                }
                catch (Exception ex)
                {
                    lblSessionInfo.Text = ex.Message;
                    Session["Username"] = null;
                    Session["Password"] = null;
                    Session["Datasource"] = ddlDatabase.SelectedValue;
                    Session["Error"] = "Unsuccessful";
                    Response.Clear();
                    Response.Redirect("default.aspx");
                }
            }
            else
            {
                Session["Username"] = null;
                Session["Password"] = null;
                Session["Datasource"] = null;
                Session["Error"] = "Incorrect";
                Response.Clear();
                Response.Redirect(Request.Url.ToString(), true);
            }
        }
    
        protected void ErrorMessage()
        {
            int length = errorMessage.Length / 2;
    
            for (int i = 0; i < length; i++)
                if (Session["Error"].ToString() == errorMessage[0, i])
                    lblSessionInfo.Text = errorMessage[1, i];
        }
    }
