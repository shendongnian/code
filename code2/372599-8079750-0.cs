    public partial class frmPersonnel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1;
                DateTime dt2;
                if (txtFirstName.Text == "")
                {
                    txtFirstName.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Please enter first name";
                }
                if (txtLastName.Text == "")
                {
                    txtLastName.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Please enter last name!";
                }
                if (txtPayRate.Text == "")
                {
                    txtPayRate.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Please enter pay rate!";
                }
                if (txtStartDate.Text == "")
                {
                    txtStartDate.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Please enter start date!";
                }
                if (txtEndDate.Text == "")
                {
                    txtEndDate.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Please enter end date!";
                }
                dt1 = DateTime.Parse(txtStartDate.Text);
                dt2 = DateTime.Parse(txtEndDate.Text);
                if (DateTime.Compare(dt1, dt2) > 0)
                {
                    txtStartDate.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Start Date must not be greater than End Date.";
                }
                else
                {
                    Session["txtFirstName"] = txtFirstName.Text;
                    Session["txtLastName"] = txtLastName.Text;
                    Session["txtPayRate"] = txtPayRate.Text;
                    Session["txtStartDate"] = txtStartDate.Text;
                    Session["txtEndDate"] = txtEndDate.Text;
                    Server.Transfer("frmPersonalVerified.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Please enter valid data!";
            }
        }
    }
