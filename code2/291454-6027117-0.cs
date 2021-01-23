    //Declare Class Scoped DataSet and DataTable variables
    DataSet ds;
    DataTable dt;
    
    //Bind repeater and DataSource method
    private void PhysicianSource()
    {
        ds = new DataSet();
        dt = ds.Tables.Add("Source");
        dt.Columns.Add("ID", Type.GetType("System.String"));
        dt.Columns.Add("Desc", Type.GetType("System.String"));
    
        Provider oProvider = new Provider();
        List<ProviderLabel> lstprovider = oProvider.RetrievePhysicianList();
        foreach (ProviderLabel item in lstprovider)
        {
            DataRow dr = dt.NewRow();
            dr[0] = item.ProviderCode.ID.ToString();
            dr[1] = item.Name.ToString();
            dt.Rows.Add(dr);
        }
    
        drpPhysicianCode.DataSource = ds;
        drpPhysicianCode.DataMember = "Source";
        drpPhysicianCode.DataTextField = "ID";
        drpPhysicianCode.DataValueField = "ID";
        drpPhysicianCode.DataBind();
    }
    //Repeater Item Data Bound event in which we would find Controls to be bound
    //and set DataSource and SelectedValue
    protected void rptrPatientList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DropDownList DropDownList1 = e.Item.FindControl("DropDownList1") as DropDownList;
            if (DropDownList1 != null)
            {
               DropDownList1.DataSource = dt;
               DropDownList1.DataBind();
               DropDownList1.SelectedValue = // DataBinder Eval 'Code' //;
            }
        }
    }
    <asp:Repeater ID="rptrPatientList" runat="server" OnItemDataBound="rptrPatientList_ItemDataBound">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="style2">
                <asp:DropDownList  ID="DropDownList1"
                    DataTextField="ID" runat="server"
                    DataValueField="Desc"
                    SelectedValue='<%# Eval("Code") %>'
                    DataSource="ds">
                </asp:DropDownList>
                </td>
    
                </td>
            </tr>
