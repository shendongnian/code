    IEnumerable<Document> getAttachments()
    {
        return ((List<Document>)Session[Request.QueryString["documentList"]]).Select(doc => doc);
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        sendMail(getAttachments());
        // or if sendMail doesn't accept IEnumerable then do :
        //sendMail(getAttachments().ToList());
    }
