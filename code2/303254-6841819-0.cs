    private bool allowCheck = false;
    private bool preventOverflow = true;
    private void lstvwRaiseLimitStore_MouseClick(object sender, MouseEventArgs e)
        {
            preventOverflow = false;
            ListViewItem item = lstvwRaiseLimitStore.HitTest(e.X, e.Y).Item;
            if (item.Checked)
            {
                allowCheck = true;
                item.Checked = false;
            }
            else
            {
                allowCheck = true;
                item.Checked = true;
            }
        }
    private void lstvwRaiseLimitStore_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!preventOverflow)
            {
                if (!allowCheck)
                {
                    preventOverflow = true;
                    e.Item.Checked = !e.Item.Checked;
                }
                else
                    allowCheck = false;
            }
        }
