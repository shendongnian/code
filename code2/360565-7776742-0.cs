       <MasterTableView  DataKeyNames="ID">
    
    <Columns>
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" ToolTip="Edit" CommandName="Edit" />&nbsp;&nbsp;&nbsp;<asp:Button
                                    ID="btnDelete" runat="server" ToolTip="Delete" CommandName="Delete" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
.........................
    protected void grdCompCliente_ItemCommand(object sender, GridCommandEventArgs e)
    {
            if (e.CommandName == "Edit")
            {
                GridDataItem item = e.Item as GridDataItem;
                string ID = item.GetDataKeyValue("ID").ToString();
                string Name = item["Name"].Text;
            }
            else if (e.CommandName == "Delete")
            {
                GridDataItem item = e.Item as GridDataItem;
                string ID = item.GetDataKeyValue("ID").ToString();
                string Name = item["Name"].Text;
            }
    }
