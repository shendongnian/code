    public static class NativeMethods
    {
        const Int32 LVM_FIRST = 0x1000;
        const Int32 LVM_SCROLL = LVM_FIRST + 20;
    
        [DllImport("user32")]
        static extern IntPtr SendMessage(IntPtr Handle, Int32 msg, IntPtr wParam, IntPtr lParam);
    
    
        // offset of window style value
        const int GWL_STYLE = -16;
    
        // window style constants for scrollbars
        const int WS_VSCROLL = 0x00200000;
        const int WS_HSCROLL = 0x00100000;
    
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    
    
        static ScrollBars GetControlVisibleScrollbars(Control ctl)
        {
            int wndStyle = GetWindowLong(ctl.Handle, GWL_STYLE);
            bool hsVisible = (wndStyle & WS_HSCROLL) != 0;
            bool vsVisible = (wndStyle & WS_VSCROLL) != 0;
    
            if(hsVisible)
                return vsVisible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                return vsVisible ? ScrollBars.Vertical : ScrollBars.None;
        }
    
        public static ScrollBars GetVisibleScrollbars(this ListView lv)
        {
            if(lv is null)
            {
                throw new ArgumentNullException(nameof(lv));
            }
    
            return GetControlVisibleScrollbars(lv);
        }
    
    
        public static ScrollBars GetVisibleScrollbars(this ScrollableControl ctl)
        {
            if(ctl is null)
            {
                throw new ArgumentNullException(nameof(ctl));
            }
    
            if(ctl.HorizontalScroll.Visible)
                return ctl.VerticalScroll.Visible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                return ctl.VerticalScroll.Visible ? ScrollBars.Vertical : ScrollBars.None;
        }
    
    
        private static void ScrollHorizontal(Form form, int pixelsToScroll)
        {
            SendMessage(form.Handle, LVM_SCROLL, (IntPtr)pixelsToScroll, IntPtr.Zero);
        }
    
        public static void EnsureVisible(this ListViewItem item, int subItemIndex, int margin=10)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
    
            if( subItemIndex > item.SubItems.Count - 1)
            {
                throw new IndexOutOfRangeException($"ListView {item.ListView.Name} does not have a SubItem on index {subItemIndex}");
            }
    
            // scroll to the item row.
            item.EnsureVisible();
            Rectangle bounds = item.SubItems[subItemIndex].Bounds;
            bounds.Width = item.ListView.Columns[subItemIndex].Width;
            ScrollToRectangle(item.ListView,bounds,margin);
        }
    
    
    
        private static void ScrollToRectangle(ListView listView, Rectangle bounds, int margin)
        {
            int scrollToLeft = bounds.X + bounds.Width + margin;
            if(scrollToLeft > listView.Bounds.Width)
            {
                ScrollHorizontal(listView.FindForm(),scrollToLeft - listView.Bounds.Width);
            }
            else
            {
                int scrollToRight = bounds.X - margin;
                if(scrollToRight < 0)
                {
                    ScrollHorizontal(listView.FindForm(),scrollToRight);
                }
            }
        }
