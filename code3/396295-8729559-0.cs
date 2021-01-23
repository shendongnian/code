     protected void btnImgBack_Click(object sender,EventArgs e)
     {
       try
       {
         gdvFile.DataSource = GetFiles();
         gdvFile.PageIndex=1;
         gdvFile.DataBind();
       }
       catch(Exception ex)
       {
         throw ex.Message;
       }
     }
