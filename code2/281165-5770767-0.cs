    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdTest" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnSelect" Text="Select" runat="server" 
                onclick="btnSelect_Click" />
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
    
    public partial class Default3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdTest.DataSource = Book.Books;
                grdTest.DataBind();
            }
    
    
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            bool result = false;
            foreach (GridViewRow row in grdTest.Rows)
            {
                result = ((CheckBox)row.FindControl("chkSelect")).Checked;
                if (result)
                {
                    Session["Title"] = row.Cells[1].Text;
                    Session["Author"] = row.Cells[2].Text;
                }
            }
        }
    }
    
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public static List<Book> Books
        {
            get
            {
                return new List<Book>()
                           {
                               new Book{Title = "Title1",Author = "Author1"},
                               new Book{Title = "Title2",Author = "Author2"},
                               new Book{Title = "Title3",Author = "Author3"},
    
                           };
            }
    
        }
    
    }
