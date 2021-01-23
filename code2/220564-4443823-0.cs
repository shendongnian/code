    void view_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.Graphics.DrawString(e.Item.Text, drawFont, Brushes.Black, 
                new RectangleF(e.Item.Position.X,
                    e.Item.Position.Y,
                    20, 
                    160));
        }
