    protected void btnExportCSV_Click(object sender, EventArgs e)
    
    {
    
        Response.Clear();
    
        Response.Buffer = true;
    
        Response.AddHeader("content-disposition",
    
         "attachment;filename=GridViewExport.csv");
    
        Response.Charset = "";
    
        Response.ContentType = "application/text";
    
     
    
        GridView1.AllowPaging = false;
    
        GridView1.DataBind();
    
     
    
        StringBuilder sb = new StringBuilder();
    
        for (int k = 0; k < GridView1.Columns.Count; k++)
    
        {
    
            //add separator
    
            sb.Append(GridView1.Columns[k].HeaderText + ',');
    
        }
    
        //append new line
    
        sb.Append("\r\n");
    
        for (int i = 0; i < GridView1.Rows.Count; i++)
    
        {
    
            for (int k = 0; k < GridView1.Columns.Count; k++)
    
            {
    
                //add separator
    
                sb.Append(GridView1.Rows[i].Cells[k].Text + ',');
    
            }
    
            //append new line
    
            sb.Append("\r\n");
    
        }
    
        Response.Output.Write(sb.ToString());
    
        Response.Flush();
    
        Response.End();
    
    }
    -->Return only hearder,not view data.Help Me !
    Thank you !
    Email:tsmcstcd@gmail.com
