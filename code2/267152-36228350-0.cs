    public partial class CustomButton : UserControl
    {
        public new event EventHandler Click;
        private void lblText_Click(object sender, EventArgs e)
        {
            Click(this, e);
        }
    }
