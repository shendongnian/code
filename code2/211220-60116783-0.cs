      <asp:GridView ID="GridViewStatus"  runat="server">
                     <Columns>
                          <asp:TemplateField HeaderText="Status" ItemStyle-Width="100px" >
                               <ItemTemplate>      
                                  <asp:Label ID="lbljobstatusAll" runat="server" 
        Text="<%#Eval("Status")  %>"  ForeColor='<%# Eval("Status").ToString().Contains("Yes") ? System.Drawing.Color.Green : System.Drawing.Color.Blue %>' />
                               </ItemTemplate>
                            </asp:TemplateField>
                     </Columns>
        </asp:GridView>
