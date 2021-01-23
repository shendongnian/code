    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:RadioButtonList ID="RadioButtons1" runat="server" AutoPostBack="true">
            <asp:ListItem Text="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="2"></asp:ListItem>
            <asp:ListItem Text="3"></asp:ListItem>
            <asp:ListItem Text="4"></asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:DropDownList ID="DropDown1" runat="server" AutoPostBack="true">
            <asp:ListItem Text="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="2"></asp:ListItem>
            <asp:ListItem Text="3"></asp:ListItem>
            <asp:ListItem Text="4"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="DropDown2" runat="server" AutoPostBack="true">
            <asp:ListItem Text="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="2"></asp:ListItem>
            <asp:ListItem Text="3"></asp:ListItem>
            <asp:ListItem Text="4"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:DropDownList ID="DropDown3" runat="server" AutoPostBack="true">
            <asp:ListItem Text="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="2"></asp:ListItem>
            <asp:ListItem Text="3"></asp:ListItem>
            <asp:ListItem Text="4"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="RadioButtons1" />
                <asp:AsyncPostBackTrigger ControlID="DropDown1" />
                <asp:AsyncPostBackTrigger ControlID="DropDown2" />
                <asp:AsyncPostBackTrigger ControlID="DropDown3" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="LabelToUpdate"><%= "rad: " + RadioButtons1.SelectedItem.Text + "<br />" + "drop1: " + DropDown1.SelectedItem.Text + "<br />" + "drop2: " + DropDown2.SelectedItem.Text + "<br />" + "drop3: " + DropDown3.SelectedItem.Text %></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
