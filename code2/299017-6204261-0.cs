    <asp:HiddenField ID="hfSubmitCount" runat="server" Value="0" />
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int count;
        if(!int.TryParse(hfSubmitCount.Value, out count))
            count = 0;
        count++;
        hfSubmitCount.Value = count.ToString();
        if (count <= 3)
            Function1();        
        else
            MessageBox("You submitted your information more than 3 times.");
    }
