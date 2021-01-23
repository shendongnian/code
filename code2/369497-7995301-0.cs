    <asp:Repeater ID="Repeater1" runat="server" onitemdatabound="Repeater1_ItemDataBound">
       <ItemTemplate>
         <div class="user">
             Active:   <asp:label id="lblActive" Text='<%# DataBinder.Eval(Container, "DataItem.Active")%>' runat="server" />        
         </div>
        </ItemTemplate>
    </asp:Repeater>
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Do modifications here
            YourObjectName person = (YourObjectName)e.Item.DataItem;
            //you can now ref the object this row is bound to
            //example find a dom element
            Label lblActive= (Label)e.Item.FindControl("lblActive");
            
            if(person.Active == 2)
            {
                lblActive.Text = "This is great";
            }
             
        }
    }
