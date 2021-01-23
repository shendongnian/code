            SqlConnection cn = new SqlConnection("yourconnectionstring");
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();
    
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
    
            dg.RenderControl(hw);
            cn.Close();
    
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
