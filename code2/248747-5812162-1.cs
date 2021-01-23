    <ext:Button ID="Button1" runat="server" Text="Click Me" Icon="Lightning">
        <Listeners>
            <Click Handler="Ext.net.DirectMethods.SetTimeStamp();" />
        </Listeners>
    </ext:Button>            
        
    <script runat="server">
    [DirectMethod]
    public void SetTimeStamp()
    {
        this.Label1.Text = string.Concat("Server Time: ", DateTime.Now.ToLongTimeString());
    }
