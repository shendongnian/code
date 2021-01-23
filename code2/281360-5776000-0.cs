    <asp:Repeater ID="rptrInsurance" runat="server" 
        OnItemCommand="rptrInsurance_ItemCommand">
        <ItemTemplate>
            <%# Eval("Name") %>
            <asp:Button ID="Delete!" CommandName="Delete" Text="myBtn" runat="server"
                        CommandArgument='<%# Eval("ID") %>' />
        </ItemTemplate>
    </asp:Repeater>  
  
    protected void rptrInsurance_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
            {
                case "Delete":
                    {
                        HCSInsurance oInsuranceDelete = new HCSInsurance();
                        Insurance oInsurance = new Insurance();
                        oInsurance.InsuranceCode.ID = e.CommandArgument;
                        oInsuranceDelete.DeleteInsurance(oInsurance);
                    }
                    break;
                case "Edit":
                    {
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
    }
