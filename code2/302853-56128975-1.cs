         <%@ Page Language="C#" AutoEventWireup="true" CodeFile="grdvw8.aspx.cs" Inherits="grdvw8" %>
        
         
        
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        
         
        
        <html xmlns="http://www.w3.org/1999/xhtml">
        
        <head id="Head1" runat="server">
        
        <title></title>
        
        </head>
        
        <body>
        
        <form id="form1" runat="server">
        
        <div>
        
        first header name change To<asp:TextBox ID="txt1" runat="server"></asp:TextBox>
        
        <br />
        
        Second header name change To<asp:TextBox ID="txt2" runat="server"></asp:TextBox>
        
        <br />
        
        <asp:Button ID="btnChange" Text="Change Header Text" runat="server" onclick="btnChange_Click" />
        
        <asp:GridView ID="grdvw" runat="server">
        
        <HeaderStyle Font-Bold="true" ForeColor="Brown" />
        
        </asp:GridView>
        
        </div>
        
        </form>
        
        </body>
        
        </html>
    
    
    /ASPX.CS PAGE/
    
     using System;
    
    using System.Collections.Generic;
    
    using System.Linq;
    
    using System.Web;
    
    using System.Web.UI;
    
    using System.Web.UI.WebControls;
    
    using System.Data;
    
    using System.Data.SqlClient;
    
    using System.Configuration;
    
     
    
    public partial class grdvw8 : System.Web.UI.Page
    
    {
    
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["code"].ConnectionString);
    
        protected void Page_Load(object sender, EventArgs e)
    
        {
    
            Bind();
    
        }
    
     
    
        protected void Bind()
    
       {
    
             con.Open();
    
              SqlCommand cmd=new SqlCommand("select * from gridview",con);
    
              SqlDataAdapter da=new SqlDataAdapter(cmd);
    
              DataSet ds=new DataSet();
    
              da.Fill(ds);
    
            grdvw.DataSource = ds;
    
             grdvw.DataBind();
    
     
    
       }
    
     
    
        protected void btnChange_Click(object sender, EventArgs e)
    
        {
    
            if (grdvw.Rows.Count > 0)
    
            {
    
                grdvw.HeaderRow.Cells[0].Text = txt1.Text;
    
                grdvw.HeaderRow.Cells[1].Text = txt2.Text;
    
            }
    
        }
    
     
    
    }
        
         
