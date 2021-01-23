    public partial class AttendLiveSession : System.Web.UI.Page
    {
        protected void imgbtnGetItButton_Click(object sender, ImageClickEventArgs e)
        {
            MyClass c = new MyClass();
            c.SaveData(DropDownList1.SelectedValue);
        }
    }
