    <%@ Register Namespace="StackOverflowWeb" TagPrefix="sow" Assembly="StackOverflowWeb" %>
    <style> span { display: block; }</style>
    
    <sow:MultiCastButton runat="server" ID="TestClickMultiCastButton" >
        <ClickEventList>
            <asp:ListItem>Test_Click</asp:ListItem>
            <asp:ListItem>Test_Click2</asp:ListItem>
            <asp:ListItem>Test_Click3</asp:ListItem>
            <asp:ListItem>Test_Click4</asp:ListItem>
        </ClickEventList>
    </sow:MultiCastButton>
    <asp:Panel runat="server" ID="ResultPanel" />
