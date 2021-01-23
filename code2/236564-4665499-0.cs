    public partial class MyForm
    {
        ...
    
        private TextBox txtbx;
    
        ...
    
        private void createControls()
        {
            txtbx = new TextBox();
            txtbx.Text = "";
            txtbx.Name = "txtbx1";
            txtbx.Location = new Point(10, 10);
            txtbx.Height = 20;
            txtbx.Width = 50;
            Controls.Add(txtbx);
        }
    
        private void someOtherFunction()
        {
            // Do something other with the created text box.
            txtbx.Text = "abc";
        }
    }
