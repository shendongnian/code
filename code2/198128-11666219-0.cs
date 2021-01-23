    public partial class result : System.Web.UI.Page
    {
        static DataTable table1 = new DataTable("Shashank");
        static DataSet set = new DataSet("office");
    
    
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmployeeNumber.Text = HttpContext.Current.Request.Form["txtEmployeeNumber"];
            lblFirstName.Text = Request.Form["txtFirstName"];
            lblLastName.Text = Request.Form["txtLastName"];
            lblTitle.Text = Request.Form["txtTitle"];
    
            Int32 Rcount = Convert.ToInt32(table1.Rows.Count);
    
            if (Rcount == 0)
            {
    
                table1.Columns.Add("ID");
                table1.Columns.Add("FName");
                table1.Columns.Add("LName");
                table1.Columns.Add("Title");
                table1.Rows.Add(lblEmployeeNumber.Text, lblFirstName.Text, lblLastName.Text, lblTitle.Text);
                set.Tables.Add(table1);
            }
            else
            {
                if (lblEmployeeNumber.Text != "")
                {
                    DataRow dr = table1.NewRow();
                    dr["ID"] = lblEmployeeNumber.Text;
                    dr["FName"] = lblFirstName.Text;
                    dr["LName"] = lblLastName.Text;
                    dr["Title"] = lblTitle.Text;
                    table1.Rows.Add(dr);
                }
            }
    
            gvrEmp.DataSource = set;
            gvrEmp.DataBind();
    
        }
    }
