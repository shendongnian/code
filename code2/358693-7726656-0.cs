    protected void Page_Load(object sender, EventArgs e)
    {
    
            StringBuilder sb = new StringBuilder();
            String strConnString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString");
            string FileName = string.Empty;
            FileName = "venkat.txt";
            string strPath1 = Server.MapPath("AchTemplates") + "\\" + "venkat.txt";
    
            int id1 = 0;
    
            MySqlConnection cnn = new MySqlConnection(strConnString);
            cnn.Open();
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
    
    
            id1 = Convert.ToInt16(Request.QueryString["Id"]);
            string selectSQL = "Select File_Data from tblachmaster where ID IN (" + id1 + ")";
    
            MySqlCommand cmd2 = new MySqlCommand(selectSQL, cnn);
            DataSet oDataSet = new DataSet();
            MySqlDataAdapter oAdapter = new MySqlDataAdapter();
            oAdapter.SelectCommand = cmd2;
    
            oAdapter.Fill(oDataSet);
    
            DataTable dt1 = oDataSet.Tables[0];
            if (dt1 != null)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    Byte[] bytes = (Byte[])dt1.Rows[i]["File_Data"];
                    string text = Encoding.UTF8.GetString(bytes);
                    
                    sb.Append(text.ToString());
    
                }
            }
            File.WriteAllText(strPath1, sb.ToString());
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=genACH(CCD).txt");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(strPath1);
            Response.Flush();
            Response.End();
    
    }
