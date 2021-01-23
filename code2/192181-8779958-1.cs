    private void lstCartOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            listBox.Refresh();
        }
    private void lstCartOutput_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            if (listBox.SelectedIndices.Contains(e.Index))
            {
                myBrush = Brushes.Red;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 64, 64)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                
            }
            e.Graphics.DrawString(listBox.Items[e.Index].ToString(),e.Font, myBrush, e.Bounds);
            e.DrawFocusRectangle();
        }
