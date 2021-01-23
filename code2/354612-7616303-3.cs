    <%@ Register Assembly="WebApplication1" Namespace="WebApplication1" TagPrefix="wa1" %>
    ...
    <wa1:FirstColumnHeaderGridView ID="Grid1" runat="server" ...>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    Will be inside th
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    Will be inside td
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </wa1:FirstColumnHeaderGridView>
