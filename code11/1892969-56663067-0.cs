    public void GridBind()
    {
        dbcon.Open();
        SqlCommand cmd = new SqlCommand("select Id,FORMAT(Date,'yyyy/MM/dd')AS Date,Subject,Disc from NoticeBoard where school_id='" + a + "'", dbcon);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        gvTeacher.DataSource = ds;
        gvTeacher.DataBind();
        dbcon.Close();
    }
