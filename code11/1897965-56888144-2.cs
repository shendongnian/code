    protected void BtnSend_Click(object sender, EventArgs e)
    {
         lblmsg.InnerText = SendMail(txtEmailId.Text.ToString(), 
         txtMessage.Text.ToString());  //------------
    private String SendMail(String EmailId, String Message)
    {
         var task = Execute(EmailId, Message);
         task.Wait();
         return ((int)task.Result).ToString();  
    }
