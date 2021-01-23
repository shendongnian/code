    <asp:Image 
        ID="Image1" 
        runat="server" 
        ImageUrl='<%# MediaHelper.GetMediaUrl(Container.DataItem) %>' 
        Height="<%# MediaHelper.GetMediaHeight(Container.DataItem) %>" 
        Width="<%# MediaHelper.GetMediaWidth(Container.DataItem) %>"
    />
