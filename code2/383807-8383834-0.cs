    <asp:GridView runat="server" ID="gridExample" OnRowEditing="gridExample_RowEditing"
                AutoGenerateEditButton="True" AutoGenerateColumns ="false" OnRowCancelingEdit ="gridExample_RowCancelingEdit" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblID" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="drpName">
                            </asp:DropDownList>
                            <asp:HiddenField runat ="server" ID ="hdnId" Value ='<%# Eval("ID") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblName" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate >
                        <asp:TextBox runat ="server" ID="txtName" Text ='<%# Eval("Name") %>'  ></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
 
    protected void gridExample_RowEditing(object sender, GridViewEditEventArgs e)
            {
                gridExample.EditIndex = e.NewEditIndex;
                BindGrid();
    
                DropDownList dl=new DropDownList ();
                dl = (DropDownList)gridExample.Rows[gridExample.EditIndex].FindControl("drpName");
                FillDrops(dl);
    
                HiddenField hdnId = new HiddenField();
                hdnId = (HiddenField)gridExample.Rows[gridExample.EditIndex].FindControl("hdnId");
                dl.Text = hdnId.Value;
    
            }
