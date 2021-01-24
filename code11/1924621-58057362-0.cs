    public partial class ChildForm : UserControl
    {
      private void button1_Click(object sender, EventArgs e)
      {
        (Parent as ParentControl)?.CloseTab(this);
      }
    }
