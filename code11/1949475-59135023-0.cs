    protected void Button2_Click(object sender, EventArgs e)
            {
                if (FileUpload1.HasFile)
                {
                    string fileExtenstion = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileExtenstion.ToLower() != ".doc" && fileExtenstion.ToLower() != ".docx")
                    {
                        Label1.Text = "Only files of docx extenstion are allowed";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        string date = DateTime.Now.ToString("h:mm:ss tt");
                        FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
                        Label1.Text = "File Uploaded successfully";
                        Label1.ForeColor = System.Drawing.Color.Green;
                        string[] filepaths = Directory.GetFiles(Server.MapPath("~/uploads/"));
    
                        DataTable dt = new DataTable();
                        DataRow dr;
                        dt.Columns.Add("filenames");
                        dt.Columns.Add("date");
                        foreach (string filepath in filepaths)
                        {
                            dr = dt.NewRow();
                            dr["filenames"] = Path.GetFileName(filepath).ToString();
                            dr["date"] = date;
                            dt.Rows.Add(dr);
                        }
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Label1.Text = "Please upload the file";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
