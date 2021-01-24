        {
            if (e.Index < 0) return;
            e.DrawBackground();
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            using (SolidBrush bgBrush = new SolidBrush(isItemSelected ? Color.FromArgb(255, 42, 42, 42) : Color.FromArgb(255, 29, 29, 29)))
            using (SolidBrush itemBrush = isItemSelected ? new SolidBrush(Color.FromArgb(255, 62, 182, 86)) : new SolidBrush(Color.FromArgb(255, 176, 176, 176)))
            {
                string itemText = listBoxTracks.GetItemText(listBoxTracks.Items[e.Index]);
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                SizeF size = e.Graphics.MeasureString(listBoxTracks.ToString(), e.Font);
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
                e.Graphics.DrawString(itemText, e.Font, itemBrush, e.Bounds.Left + (e.Bounds.Width / 29 - size.Width / 39), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2), StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }
