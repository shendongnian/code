         <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
         <asp:RadioButtonList ID="MultiFieldRBList1" runat="server" ></asp:RadioButtonList>
        </div>
        </form>
    </body>
    </html>
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Default4 : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fetch data from database.
        var list = Game.GetAll();
        var query = from c in list
                 select new Data
                 {
                     Column1 = c.Id,
                     MultipleCplumn = c.Title + "(" + c.Year + ")"
                 };
        MultiFieldRBList1.DataSource = query;
        MultiFieldRBList1.DataTextField = "MultipleCplumn";
        MultiFieldRBList1.DataValueField = "Column1";
        MultiFieldRBList1.DataBind();
      
    }
}
public class Data
{
    public int Column1 { get; set; }
    public string MultipleCplumn { get; set; }
}
