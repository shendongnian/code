    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        try
        {
            string filename = e.FileName;
            var bytes = e.GetContents();
            var attachmentID = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            switch (ext)
            {
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            if (contenttype != String.Empty)
            {
                string constr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spUploadContentBulk", con);
                    cmd.Parameters.AddWithValue("@AttachmentID", attachmentID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@FileName",
                        Value = filename
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@FileContent",
                        Value = bytes
                    });
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@FileType",
                        Value = contenttype
                    });
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        catch (Exception ex)
        {
            txtError.Text = ex.ToString();
        }
    }
