    <h2>Doing it by hand - manually building up an HTML Table</h2>
    <asp:Panel runat="server" ID="pnl1">
    </asp:Panel>
    <h2>With a Repeater</h2>
    <asp:Repeater runat="server" id="rptNames" onItemDataBound="rptName_ItemDataBound" >
            <HeaderTemplate>
                <table border="1" style="border-color:Red;">
                    <tr>
                        <td>Given Name(s)</td>
                        <td>Family Name</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("FamilyName") %></td>
                    <td>
                        <asp:Label runat="server" id="lGivenNames" />
                    </td>
                </tr>     
            </ItemTemplate>       
            <FooterTemplate>
                </table>
            </FooterTemplate>
    </asp:Repeater>
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Web.UI.HtmlControls;
        namespace Testbed.WebControls
        {
            internal class FullName{
                public string FamilyName{get;set;}
                public string[] GivenNames{get;set;}
                public FullName(){
        
                }
                public FullName(string[] _givenNames, string _familyName)
                {
                    FamilyName = _familyName;
                    GivenNames = _givenNames;
                }
            }
            public partial class HTMLTables : System.Web.UI.Page
            {
                List<FullName> Name;
                protected void Page_Load(object sender, EventArgs e)
                {
                    this.Name = new List<FullName>();
                    Name.Add(new FullName(new string[]{"Kylie"},"Minogue"));
                    Name.Add(new FullName(new string[]{"Angelina", "Kate", "Very-Lovely"}, "Jolie"));
                    Name.Add(new FullName(new string[]{"Audrey", "Veronica"},"Hepburn"));
                    HtmlTable table = new HtmlTable();
                    table.Border = 1;
                    HtmlTableRow row;
                    HtmlTableCell cell;
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();
                    cell.InnerText = "Given Name";
                    row.Cells.Add(cell);
                    cell = new HtmlTableCell();
                    cell.InnerText = "Family Name";
                    row.Cells.Add(cell);
                    foreach (var item in Name)
                    {
                        row = new HtmlTableRow();
                        //foreach (var familyName in item.FamilyName){
                            cell = new HtmlTableCell();
                            cell.InnerText = item.FamilyName.ToString();
                            row.Cells.Add(cell);
                        //}
                        foreach (string givenName in item.GivenNames)
                        {
                            cell = new HtmlTableCell();
                            cell.InnerText = givenName.ToString();
                            row.Cells.Add(cell);
                        }
                        table.Rows.Add(row);
                    }
                    this.pnl1.Controls.Add(table);
                    //Or do it with a repeater
                    rptNames.DataSource = Name;
                    rptNames.DataBind();
            
                }
                //This gets called everytime a data object gets bound to a repeater row
                protected void rptName_ItemDataBound(object sender, RepeaterItemEventArgs e){
                    switch(e.Item.ItemType){
                        case ListItemType.Item:
                        case ListItemType.AlternatingItem:
                            string[] arrGivenNames = ((FullName)e.Item.DataItem).GivenNames;
                            foreach(string n in arrGivenNames){
                                ((Label)e.Item.FindControl("lGivenNames")).Text += n + @"&nbsp;";
                            }
                        break;
                        default:
                        break;
                    }
                }
            }
        }
