    Html Part of the code:
    
    <form id="form1" runat="server">
            <div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table border="1">
                            <tr>
                                <th>Name</th>
                                <th>Country</th>
                                <th>City</th>
                                <th>Comments</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblName" Text='<%# Eval("Name") %>' runat="server" />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblCountry_SelectedIndexChanged">
                                    <asp:ListItem Text="United States" Value="US"></asp:ListItem>
                                    <asp:ListItem Text="United Kingdom" Value="UK"></asp:ListItem>
                                    <asp:ListItem Text="Australia" Value="Aus"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </form>
    
       code behind part:
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateList();
            }
        }
        private void PopulateList()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Name", typeof(string))});
            dt.Rows.Add("John Hammond");
            dt.Rows.Add("Mudassar Khan");
            dt.Rows.Add("Suzanne Mathews");
            dt.Rows.Add("Robert Schidner");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        protected void rblCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as RadioButtonList).NamingContainer as RepeaterItem;
            string countryName = (item.FindControl("rblCountry") as RadioButtonList).Text;
            DropDownList ddlCity = item.FindControl("ddlCity") as DropDownList;
            TextBox txtCity = item.FindControl("txtCity") as TextBox;
            ListItem li;
            if (ddlCity != null)
            {
                ddlCity.Items.Clear();
                switch (countryName)
                {
                    case "US":
                        li = new ListItem() { Text = "Chicago", Value = "Chicago" };
                        ddlCity.Items.Add(li);
                        li = new ListItem() { Text = "Washington", Value = "Washington" };
                        ddlCity.Items.Add(li);
                        break;
                    case "UK":
                        li = new ListItem() { Text = "Manchester", Value = "Manchester" };
                        ddlCity.Items.Add(li);
                        li = new ListItem() { Text = "London", Value = "London" };
                        ddlCity.Items.Add(li);
                        li = new ListItem() { Text = "Scotland", Value = "Scotland" };
                        ddlCity.Items.Add(li);
                        break;
                    case "Aus":
                        li = new ListItem() { Text = "Sydney", Value = "Sydney" };
                        ddlCity.Items.Add(li);
                        li = new ListItem() { Text = "Melbourne", Value = "Melbourne" };
                        ddlCity.Items.Add(li);
                        break;
                }
                if (ddlCity != null && ddlCity.SelectedItem != null)
                    txtCity.Text = ddlCity.SelectedItem.Text;
            }
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as DropDownList).NamingContainer as RepeaterItem;
            DropDownList ddlCity = item.FindControl("ddlCity") as DropDownList;
            TextBox txtCity = item.FindControl("txtCity") as TextBox;
            txtCity.Text = ddlCity.SelectedItem.Text;
        }
