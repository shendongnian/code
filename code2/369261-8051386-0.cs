     <telerik:GridTemplateColumn>
                <ItemTemplate>
                    <asp:Label ID="Label1"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1"></asp:TextBox>
                </EditItemTemplate>
               </telerik:GridTemplateColumn>
...................
    button1_click()
    {
         // for Normal mode
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            Label Label1 = item.FindControl("Label1") as Label;
        }
        // for edit mode
        foreach (GridDataItem item in RadGrid1.EditItems)
        {
            TextBox TextBox1 = item.FindControl("TextBox") as TextBox;
        }
    }
