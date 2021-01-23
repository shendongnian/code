    /// <summary>
    /// Finds top/bottom visible items
    /// </summary>
    public static (ListViewItem, ListViewItem) GetTopBottomVisible(ListView listView)
    {
        ListViewItem topItem = listView.TopItem;
        int lstTop = listView.Top;
        int lstHeight = lstTop + listView.Height;
        int lstBottom = lstHeight;
        int step = lstHeight/2;
        int x = listView.Left + listView.Width/2;
        int y = lstTop + step;
        ListViewItem bottomCandidate=null;
        // iterate by interval halving
        while ( step > 0 )
        {
            step /= 2; // halv interval
            ListViewItem itm = listView.GetItemAt(x, y);
            if ( itm == null )
            {
                // below last, move up
                y -= step;
            }
            else if ( itm == bottomCandidate )
            {
                // Moving still in same item, stop here
                break;
            }
            else
            {
                // above last, move down, storing candidate
                bottomCandidate = itm;
                y += step;
            }
        }
        return (topItem, bottomCandidate);
    }
