        <%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>
    
    <!DOCTYPE html>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="Country_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="Canada" Text="Canada"></asp:ListItem>
                    <asp:ListItem Value="USA" Text="USA"></asp:ListItem>
                </asp:DropDownList>
               
            </div>
             <br />
                <asp:TextBox ID="txtShow" runat="server"></asp:TextBox>
        </form>
    </body>
    </html>
    
        
        
        ----------------------------aspx.cs code---------------------------------------
        
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
        
            protected void Country_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(ddlCountry.SelectedValue.ToString() == "USA")
                {
                    txtShow.Attributes.Add("Placeholder", "State");
                }
        
                if (ddlCountry.SelectedValue.ToString() == "Canada")
                {
                    txtShow.Attributes.Add("Placeholder", "Province");
                }
            }
        }
