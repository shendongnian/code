    protected void btnSubmit_Click(object sender, EventArgs e) {
        if(SaveRecordsToDataDatabase())
        {
           If(UploadImage())
           {
    
               showMessage("Save successfull",true);
           }
           else
           {
              showMessage("Save failed",false);
           }
        }
        else
           {
              showMessage("Save failed",false);
           }
    }
    
    private bool UploadImage()
    {
      // you upload image code..
    }
    
    private bool SaveRecordsToDatabase()
    {
      // db save code
    }
    
    private void showMessage(string message, bool success)
    {
        lblMsg.visible = true; // here lblMsg is asp label control on your aspx page.
        lblMsg.FontBold = true;
        if(success)
           lblMsg.ForeColor = Color.Green;
        else
           lblMsg.ForeColor = Color.Green;
        lblMsg.Text = message;
    }
