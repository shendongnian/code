<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_testPWforSO.aspx.cs" Inherits="_testPWforSO" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="phTest" runat="server" />
        </div>
    </form>
</body>
</html>
using System;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
public class EventList
{
    public int Id { get; set; }
    public string EventName { get; set; }
    // more variables
}
public partial class _testPWforSO :  System.Web.UI.Page
{
    public void Page_Load(Object sender, EventArgs e)
    {
        EventList test = new EventList() { Id = 12, EventName = "test123" };
        EventList test1 = new EventList() { Id = 34, EventName = "test456" };
        List<EventList> events = new List<EventList>() { test, test1 };
        TestFunction(events);
    }
    public void TestFunction(List<EventList> events)
    {
        HtmlTable table = new HtmlTable();
        // add table headers if you want
        foreach (EventList item in events)
        {
            table.Rows.Add(AddRow(item));
        }
     
        phTest.Controls.Add(table);
    }
    public HtmlTableRow AddRow(EventList item)
    {
        HtmlTableRow result = new HtmlTableRow();
        result.Cells.Add(new HtmlTableCell() { InnerText = item.EventName });
        result.Cells.Add(new HtmlTableCell() { InnerText = item.Id.ToString() });
        return result;
    }
}
