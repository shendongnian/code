    public class MyToolStripComboBox : ToolStripComboBox
    {
        public MyToolStripComboBox()
        {
            this.ComboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }
        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!this.ComboBox.DroppedDown)
                ((HandledMouseEventArgs)e).Handled = true;
        }
    }
