        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExt = 
                   System.IO.Path.GetExtension(FileUpload1.FileName);
    
                if (fileExt == ".jpeg" || fileExt == ".jpg")
                {
                    //do what you want with this file
                }
                else
                {
                    Label1.Text = "Only .jpeg files allowed!";
                }
            }
            else
            {
                Label1.Text = "You have not specified a file.";
            }
        }
