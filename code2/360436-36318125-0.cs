    class TabControlEx : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0005) // WM_SIZE
            {
                int Width = unchecked((short)m.LParam);
                int Height = unchecked((short)((uint)m.LParam >> 16));
                // Remove the annoying white pixels on the outside of the tab control
                // by adjusting the control's clipping region to exclude the 2 pixels
                // on the right and one pixel on the bottom.
                Region = new Region(new Rectangle(0, 0, Width - 2, Height - 1));
            }
            base.WndProc(ref m);
        }
    }
