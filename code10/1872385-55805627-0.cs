    <!DOCTYPE html>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <div id="div1">
                    <asp:DropDownList ID="ddl1" runat="server" OnSelectedIndexChanged="ddl1_SelectedIndexChanged" AutoPostBack="true">
                         <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    </asp:DropDownList>
                </div><br /><br />
                 <div id="div2">
                    <asp:DropDownList ID="ddl2" runat="server" OnSelectedIndexChanged="ddl2_SelectedIndexChanged" AutoPostBack="true">
                          <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    </asp:DropDownList>
                </div><br /><br />
                 <div id="div3">
                    <asp:DropDownList ID="ddl3" runat="server" OnSelectedIndexChanged="ddl3_SelectedIndexChanged" AutoPostBack="true">
                          <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    </asp:DropDownList>
                </div><br /><br />
                 <div id="div4">
                    <asp:DropDownList ID="ddl4" runat="server" OnSelectedIndexChanged="ddl4_SelectedIndexChanged" AutoPostBack="true">
                          <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </form>
    </body>
    </html>
    
    
    
    ------------------------------aspx.cs code-----------------------------
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    
        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl1.SelectedValue == ddl1.SelectedValue)
            {
                ddl2.Items.Remove(ddl1.SelectedValue);
                ddl3.Items.Remove(ddl1.SelectedValue);
                ddl4.Items.Remove(ddl1.SelectedValue);
            }
        }
    
        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl2.SelectedValue == ddl2.SelectedValue)
            {
                ddl1.Items.Remove(ddl2.SelectedValue);
                ddl3.Items.Remove(ddl2.SelectedValue);
                ddl4.Items.Remove(ddl2.SelectedValue);
            }
        }
    
        protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl3.SelectedValue == ddl3.SelectedValue)
            {
                ddl1.Items.Remove(ddl3.SelectedValue);
                ddl2.Items.Remove(ddl3.SelectedValue);
                ddl4.Items.Remove(ddl3.SelectedValue);
            }
        }
    
        protected void ddl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl4.SelectedValue == ddl4.SelectedValue)
            {
                ddl1.Items.Remove(ddl4.SelectedValue);
                ddl2.Items.Remove(ddl4.SelectedValue);
                ddl3.Items.Remove(ddl4.SelectedValue);
            }
        }
    }
