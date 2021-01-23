    ----------------aspx page code------------------
    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>
    
    <!DOCTYPE html>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
               <asp:Label ID="lblRandom" runat="server"></asp:Label>
            </div>
        </form>
    </body>
    </html>
    
    
    ------------------aspx.cs page code-------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Test : System.Web.UI.Page
    {
        static Random random = new Random();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            randomnumber();
        }
    
        private void randomnumber()
        {
            lblRandom.Text = Convert.ToString(random.Next(10, 300));
        }
    }
