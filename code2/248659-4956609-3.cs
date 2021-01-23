    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <asp:ListView runat="server" ID="_simpleTableListView" OnItemDataBound="_simpleTableListView_ItemDataBound">
                <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    ID
                                </th>
                                <th>
                                    Title
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("title") %>
                        </td>
                        <td>
                            <asp:GridView ID="MyGridView" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
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
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _simpleTableListView.DataSource = new Movie().GetAll;
            _simpleTableListView.DataBind();
    
        }
       
        protected void _simpleTableListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            GridView gv= ((GridView)e.Item.FindControl("MyGridView"));
    
        }
    }
    
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
    
        public List<Movie> GetAll
        {
    
            get
            {
                return new List<Movie>()
                {
                    new Movie{Id=1,Title="A"},
                    new Movie{Id=2,Title="B"},
                };
            }
        }
    }
