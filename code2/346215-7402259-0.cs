    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs"   Inherits="_Default" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org   /TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Datalist with linkable items</title>
      </head>
      <body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:DataList ID="dlLinkable" runat="server" 
            onitemdatabound="dlLinkable_ItemDataBound" >
            <ItemTemplate>
                <table style="width: 300px;" cellpadding="0" cellspacing="1">
                    <tr>
                        <td style="width:200px">
                            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <a id="linkA" runat="server">link</a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
    </body>
    </html>
    using System;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    public partial class _Default : System.Web.UI.Page
    {
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        populateDataList();
    }
    private void populateDataList()
    {
        dt = new DataTable();
        //Create 3 columns for this DataTable
        DataColumn col1 = new DataColumn("ID");
        DataColumn col2 = new DataColumn("Name");
        DataColumn col3 = new DataColumn("Url");
        //Add All These Columns into DataTable table
        dt.Columns.Add(col1);
        dt.Columns.Add(col2);
        dt.Columns.Add(col3);
        // Create a Row in the DataTable table
        DataRow row = dt.NewRow();
        row[col1] = 1;
        row[col2] = "google";
        row[col3] = "http://www.google.com";
        dt.Rows.Add(row);
        //////////////////////
        row = dt.NewRow();
        row[col1] = 2;
        row[col2] = "yahoo";
        row[col3] = "http://www.yahoo.com";
        dt.Rows.Add(row);
        //////////////////////////////////
        dlLinkable.DataSource = dt;
        dlLinkable.DataBind();
    }
      protected void dlLinkable_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType ==   ListItemType.Item)
         {
            Label lblName = (Label)e.Item.FindControl("lblName");
            if (lblName != null)
            {
                lblName.Text = dt.Rows[e.Item.ItemIndex]["Name"].ToString();
            }
            HtmlAnchor linkA = (HtmlAnchor)e.Item.FindControl("linkA");
            if (linkA != null)
            {
                linkA.HRef = dt.Rows[e.Item.ItemIndex]["Url"].ToString();
            }
        }
      }
   }
