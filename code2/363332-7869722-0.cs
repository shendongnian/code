    public partial class MyListView : ListView
    {
        public MyListView()
        {
        }
        public delegate void ColumnContextMenuHandler(object sender, ColumnHeader columnHeader);
        public event ColumnContextMenuHandler ColumnContextMenuClicked = null;
        bool _OnItemsArea = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _OnItemsArea = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _OnItemsArea = false;
        }
        const int WM_CONTEXTMENU = 0x007B;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CONTEXTMENU)
            {
                long l = (long)m.LParam;
                Point p = base.PointToClient(MousePosition);
                                
                if (!_OnItemsArea)
                {
                    int totalWidth = 0;
                    foreach (ColumnHeader column in base.Columns)
                    {
                        totalWidth += column.Width;
                        if (p.X < totalWidth)
                        {
                            if (ColumnContextMenuClicked != null) ColumnContextMenuClicked(this, column);
                            break;
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
