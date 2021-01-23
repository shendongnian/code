    protected void gvBlockUnblock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
    string ComplaintProfileId = gvBlockUnblock.DataKeys[gvBlockUnblock.SelectedIndex].Values["CPID"].ToString();
        string ISPUBLISHED = gvBlockUnblock.DataKeys[gvBlockUnblock.SelectedIndex].Values["PUBLISHED"].ToString();
        string date = System.DateTime.Now.ToString();
        TextBox tb = (TextBox)gvBlockUnblock.Rows[gvBlockUnblock.SelectedIndex].FindControl("txtAdminComment");
        string Comment = tb.Text;
        if (string.IsNullOrEmpty(Comment))
        {
            WebMsgBox.Show("empty");
        }
        else
        {
            if (ISPUBLISHED == "N")
            {
                ISPUBLISHED = "N";
            }
            else
            {
                ISPUBLISHED = "Y";
            }
            string AdminComment = (System.DateTime.Now.ToString() + " :  " + Comment);
            AddCommentBLL.InsertComment(AdminComment, ComplaintProfileId, ISPUBLISHED);
            gvBlockUnblock.DataSource = AddCommentBLL.GetItem();
            gvBlockUnblock.DataBind();
        }
        }
    }
