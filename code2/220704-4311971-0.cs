    this.Invoke(new MethodInvoker(() => 
    {
        strFrom = txtFrom.Text; 
        strTo = txtTo.Text; 
        strMessageBody = txtMessageBody.Text; 
        strStartDate = txtStartDate.Text; 
        strEndDate = txtEndDate.Text; 
        intStatus = ddlStatus.SelectedIndex;
    })); 
