    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" 
            DataSourceID="SqlDataSource1" GridLines="None">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProductID, ProductName"  
                            DataSourceID="SqlDataSource1">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="ProductID" DataType="System.Int32" 
                        FilterControlAltText="Filter ProductID column" HeaderText="ProductID" 
                        ReadOnly="True" SortExpression="ProductID" UniqueName="ProductID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ProductName" 
                        FilterControlAltText="Filter ProductName column" HeaderText="ProductName" 
                        SortExpression="ProductName" UniqueName="ProductName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SupplierID" DataType="System.Int32" 
                        FilterControlAltText="Filter SupplierID column" HeaderText="SupplierID" 
                        SortExpression="SupplierID" UniqueName="SupplierID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UnitPrice" DataType="System.Decimal" 
                        FilterControlAltText="Filter UnitPrice column" HeaderText="UnitPrice" 
                        SortExpression="UnitPrice" UniqueName="UnitPrice">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Update"> 
                    <ItemTemplate> 
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" /> 
                    </ItemTemplate> 
                </telerik:GridTemplateColumn> 
                </Columns>
            <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False"></FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
        </telerik:RadGrid>
