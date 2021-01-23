    private void ListView1_DrawColumnHeader(object sender, System.Windows.Forms.DrawListViewColumnHeaderEventArgs e) {
        e.DrawDefault = true;
    }
    
    private void ListView1_DrawSubItem(object sender, System.Windows.Forms.DrawListViewSubItemEventArgs e) {
        if (!(e.Item.SubItems(0) == e.SubItem)) {
            e.DrawDefault = false;
            e.DrawBackground();
            e.Graphics.DrawImage(My.Resources.Image1, e.SubItem.Bounds.Location);
            e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, new SolidBrush(e.SubItem.ForeColor), (e.SubItem.Bounds.Location.X + My.Resources.Image1.Width), e.SubItem.Bounds.Location.Y);
        }
        else {
            e.DrawDefault = true;
        }
    }
