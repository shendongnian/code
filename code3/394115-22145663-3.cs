       protected void Button1_Click(object sender, EventArgs e)
           {
        Label1.Visible = true;
        Label2.Visible = true;
        Label1.Text = "Login Information Data";
        Label2.Text = Convert.ToString(System.DateTime.Now);
        if (GridView1.Visible == true)
        {
            // GridViewExportUtil.Export("StateReport.xls", GridView1);
            GridViewExportUtil.ExportGridView("LoginInformation.xls", GridView1, Label1, Label2);
        }
           }
