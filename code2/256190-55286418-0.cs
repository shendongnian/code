    <%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>
    
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>
        <input id="Button1" type="button" value="button"  runat="server" onclick="alert('hi'); " onserverclick="Button1_ServerClick"/>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" OnClientClick="alert('hi'); "  />
    </asp:Content>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication2
    {
        public partial class About : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_ServerClick(object sender, EventArgs e)
            {
                Response.Write("hello");
            }
    
            protected void Button2_Click(object sender, EventArgs e)
            {
                Response.Write("hello");
            }
        }
    }
