                <asp:TemplateField HeaderText="Favourite Teacher" >
                    <ItemTemplate>
                        <asp:Label ID="lblfavorite_teacher" runat="server" Text='<%# LookupTeacherName(DataBinder.Eval(Container.DataItem, "id")) %>'></asp:Label> 
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlfavorite_teacher" runat="server" DataSourceID="sds_teacher_table" DataTextField="name" DataValueField="id" SelectedValue='<%#Bind("id")%>' Width="98%">
                        </asp:DropDownList> 
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddlNewfavorite_teacher" runat="server" DataSourceID="sds_teacher_table" DataTextField="name" DataValueField="id" SelectedValue='<%#Bind("id")%>' Width="95%">
                        </asp:DropDownList> 
                    </FooterTemplate>
                   <ItemStyle Width="25%" /> 
               </asp:TemplateField>
        protected string LookupTeacherName(object idObj)
        {
            if (string.IsNullOrEmpty(idObj.ToString()))
                return null;
            string TeacherId = idObj.ToString();
            // find the corresponding name
            IEnumerator enumos = sds_teacher_table.Select(new DataSourceSelectArguments()).GetEnumerator();
            while (enumos.MoveNext())
            {
                DataRowView row = enumos.Current as DataRowView;
                if ((string)row["id"].ToString() == TeacherId)
                    return string.Concat(row["name"].ToString());
            }
            return TeacherId;
        }
