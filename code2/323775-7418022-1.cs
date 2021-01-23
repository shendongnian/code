    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            if (FileUpload1.HasFile)
            {
                String fileExt = Path.GetExtension(FileUpload1.FileName);
                if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".jpeg" || fileExt == ".png")
                {
                    String path = "~/Image/" + FileUpload1.FileName;
                    cmd.CommandText = "update " + HttpContext.Current.User.Identity.Name + " set image = '" + path + "'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    FileUpload1.SaveAs(Server.MapPath("~/Image/") + FileUpload1.FileName);
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    lblPicStatus.Text = "File to be uploaded is not an image";
                }
                con.Close();
            }
        }
        catch (Exception a)
        {
            Response.Write(a.Message);
        }
    }
