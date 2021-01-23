    <asp:Label runat="server" ID="lblChangeOrders"
        OnDataBinding="lbChangeOrder_DataBinding"></asp:Label>
    protected void lbChangeOrder_DataBinding(object sender, System.EventArgs e)
    {
        Label lbl = (Label)(sender);    
        double sum = (double)(Eval("Sum"));
        if (sum < 0)
        {
            sum *= -1;
            lbl.ForeColor = "Red";
        }
        lbl.Text = sum.ToString();     
    }
