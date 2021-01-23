    public class CustomListBox : ListBox
    {
        public void SetSelected()
        {
            this.MouseDown += new MouseEventHandler(this.DeselectAll);
        }
        public void UnsetSelected()
        {
            this.MouseDown -= new MouseEventHandler(this.DeselectAll);
        }
        private void DeselectAll(object sender, MouseEventArgs e)
        {
            // ...
        }
    }
