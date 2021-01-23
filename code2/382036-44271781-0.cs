    private void InitializeComponent()
    {
        ...
        this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
        ...
     }
    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush brush = Brushes.Black;
            var rect = new Rectangle(e.Bounds.X+10, e.Bounds.Y+8, 12, 14);
           //assuming the icon is already added to project resources
            e.Graphics.DrawIconUnstretched(YourProject.Properties.Resources.YouIcon, rect);
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, brush, new Rectangle(e.Bounds.X + 25, e.Bounds.Y + 10, e.Bounds.Width, e.Bounds.Height), StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
