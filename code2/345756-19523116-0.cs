        <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>                      
                        <asp:MenuItem>
                           <asp:MenuItem></asp:MenuItem>
                           <asp:MenuItem></asp:MenuItem>
                        </asp:MenuItem>
                            
                    </Items>
                </asp:Menu>
        NavigationMenu.Items[0].Text = "xxxxxx"; name of menu
        MenuItem menu = NavigationMenu.Items[0];
        MenuItem submenu = new MenuItem("xxxxxx"); //name of submenu
        submenu.NavigateUrl = "~/Main/xxxxx.aspx?id=" + id + "";
        MenuItem submenu1 = new MenuItem("xxxxxxx");//name of sumbenu1
        submenu1.NavigateUrl = "~/Main/xxxxxxx.aspx?id=" + id + "";
        menu.ChildItems.Add(submenu);
        menu.ChildItems.Add(submenu1);
