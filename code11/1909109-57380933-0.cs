<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlCategories" runat="server" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged"/>
            <asp:PlaceHolder ID="QuestionTable" runat="server" />
        </div>
    </form>
</body>
</html>
CODE-BEHIND
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Text;
public partial class _testPWforSO :  System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Populate dropdown list first, and set the default value if we want
            PopulateCategoryDropdown();
            // Bind Question Table after, so we can access the dropdown list selected value
            BuildQuestionsTable();
        }
    }
    private DataTable GetData()
    {
        // function that gets our data via dropdown lists selected value
        return new DataTable();
    }
    private void PopulateCategoryDropdown()
    {
        // categories will be whatever datasource you use to populate dropdown list
        Collection<object> categories = new Collection<object>();
        this.ddlCategories.DataSource = categories;
        this.ddlCategories.DataBind();
        // this.ddlCategories.SelectedValue = "";
    }
    protected void BuildQuestionsTable()
    {
        //Populating a DataTable from database.
        DataTable dt = this.GetData();
        //Building an HTML string.
        StringBuilder html = new StringBuilder();
        //Table start.
        html.Append("<table class='table'>");
        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("<th> Edit </th>");
        html.Append("<th> Delete </th>");
        html.Append("</tr>");
        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td align='left'>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("<td align='left'> <button type='button' class='btn btn-warning'>Edit</button> </td>");
            html.Append("<td align='left'> <button type='button' class='btn btn-danger'>Delete</button> </td>");
            html.Append("</tr>");
        }
        //Table end.
        html.Append("</table>");
        //Append the HTML string to Placeholder.
        QuestionTable.Controls.Add(new Literal { Text = html.ToString() });
    }
    protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuildQuestionsTable();
    }
}
