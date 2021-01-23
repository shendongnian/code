    private void lstCartOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            listBox.Invalidate();
        }
    private void lstCartOutput_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int index = e.Index;
            Graphics g = e.Graphics;
            Font font = listBox.Font;
            Color colour = listBox.ForeColor;
            string text = listBox.Items[index].ToString();
            
            foreach (int selectedIndex in listBox.SelectedIndices)
            {
                e.DrawBackground();
                if (index == selectedIndex)
                {
                    // Draw the new background colour    
                    g.FillRectangle(new SolidBrush(Color.Red),e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBox.Font.Height);
                    g.DrawString(text, font, new SolidBrush(Color.White), (float)e.Bounds.X, (float)e.Bounds.Y);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.White), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, listBox.Font.Height);
                    g.DrawString(text, font, new SolidBrush(Color.Black), (float)e.Bounds.X, (float)e.Bounds.Y);
                }
            }
            e.DrawFocusRectangle(); 
        }
