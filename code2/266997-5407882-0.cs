       <asp:TemplateField HeaderText="Dinamična vsebina">
            <ItemTemplate>
                <asp:TextBox ID="txtDynamicValue" runat="server"
                     Text='<%#Eval("DynamicValue")%>' AutoPostBack="True"
                     ontextchanged="txtDynamicValue_TextChanged"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <%protected void txtDynamicValue_TextChanged(object sender, EventArgs e)
        {
            /*TextBox txt = (TextBox)sender;
            RulesManagerPresenter.OnDynamicValueChanged(txt.Text, GetTagName(txt.NamingContainer), QueryStringRuleGroup);
            presenter.OnLoadTagsAndValues4Presentation(ConnectionString);*/
        }%>
