    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        listView1.OwnerDraw = true;
        listView1.View = View.LargeIcon;
        listView1.DrawItem += ListView1_DrawItem;
        listView1.MouseEnter += ListView1_MouseEnter;
        listView1.MouseMove += ListView1_MouseMove;
        listView1.MouseLeave += ListView1_MouseLeave;
        for (int i = 1; i <= 10; ++i)
        {
            listView1.Items.Add($"item {i}", 0);
        }
    }
    private void ListView1_MouseEnter(object sender, EventArgs e)
    {
        CheckHoveredAndInvalidate();
    }
    private void ListView1_MouseLeave(object sender, EventArgs e)
    {
        RemoveHoveredAndInvalidate();
    }
    internal static Rectangle GetEntireItemBounds(ListViewItem it)
    {
        return it.GetBounds(ItemBoundsPortion.Entire);
    }
    internal ListViewItem GetEntireItemAtCursorPosition()
    {
        Point p = listView1.PointToClient(Cursor.Position);
        foreach (ListViewItem it in listView1.Items)
        {
            if (GetEntireItemBounds(it).Contains(p))
            {
                return it;
            }
        }
        return null;
    }
    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
        CheckHoveredAndInvalidate();
    }
    private void CheckHoveredAndInvalidate()
    {
        ListViewItem item = GetEntireItemAtCursorPosition();
        if (item == null)
        {
            RemoveHoveredAndInvalidate();
        }
        else if (item != null)
        {
            if (LastHoveredItem != null)
            {
                if (LastHoveredItem != item)
                {
                    ListViewItem item2 = LastHoveredItem;
                    LastHoveredItem = item;
                    listView1.Invalidate(GetEntireItemBounds(item2));
                    listView1.Invalidate(GetEntireItemBounds(item));
                }
                else if (LastHoveredItem == item)
                {
                }
            }
            else if (LastHoveredItem == null)
            {
                LastHoveredItem = item;
                listView1.Invalidate(GetEntireItemBounds(item));
            }
        }
    }
    private void RemoveHoveredAndInvalidate()
    {
        if (LastHoveredItem != null)
        {
            ListViewItem item2 = LastHoveredItem;
            LastHoveredItem = null;
            listView1.Invalidate(GetEntireItemBounds(item2));
        }
        else if (LastHoveredItem == null)
        {
        }
    }
    private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        if (LastHoveredItem == e.Item)
        {
            e.Graphics.FillRectangle(Brushes.Yellow, e.Item.Bounds);
        }
        else
        {
            e.Graphics.FillRectangle(Brushes.Green, e.Item.Bounds);
        }
    }
