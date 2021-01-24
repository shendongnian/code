<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_testForPw.aspx.cs" Inherits="_testForPw" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlTest" runat="server" />
        </div>
    </form>
</body>
</html>
CODE BEHIND
using System.Web.UI.WebControls;
public partial class _testForPw :  System.Web.UI.Page
{
    
    public void Page_Load(object sender, EventArgs e)
    {
        TestClass obj1 = new TestClass() { Id = "1234", Name = "Test" };
        TestClass obj2 = new TestClass() { Id = "5678", Name = "FooBar" };
        Collection<TestClass> objs = new Collection<TestClass>() { obj1, obj2 };
        this.ddlTest.DataSource = objs;
        this.ddlTest.DataTextField = "Name";
        this.ddlTest.DataValueField = "Id";
        this.ddlTest.DataBind();
    }
}
public partial class TestClass
{
    public string Id { get; set; }
    public string Name { get; set; }
}
