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
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Web.UI.WebControls;
public partial class _testForPw :  System.Web.UI.Page
{
    
    public void Page_Load(object sender, EventArgs e)
    {
        TestClass obj1 = new TestClass() { Id = "1234", Name = "Test" };
        TestClass obj2 = new TestClass() { Id = "5678", Name = "FooBar" };
        Collection<TestClass> objs = new Collection<TestClass>() { obj1, obj2 };
        this.ddlTest.DataSource = TestClass.GetItems(objs);
        this.ddlTest.DataBind();
    }
    public partial class TestClass : ITestClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [AttributeProvider(typeof(ITestClass))]
        string ITestClass.Test
        {
            get
            {
                return "Test12345";
            }
            set
            {
                // do nothing, for testing only
            }
        }
        public static Collection<ListItem> GetItems(Collection<TestClass> objs)
        {
            Collection<ListItem> results = new Collection<ListItem>();
            foreach (TestClass item in objs)
            {
                System.Reflection.PropertyInfo info = item.GetType().GetInterface("ITestClass").GetProperty("Test");
                if (info != null)
                {
                    results.Add(new ListItem() { Text = info.GetValue(item).ToString(), Value = item.Id });
                }
            }
            return results;
        }
    }
    public interface ITestClass
    {
       string Test { get; set; }
    }
}
