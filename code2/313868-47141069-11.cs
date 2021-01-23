    using System;
    using System.Drawing;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    // Here comes your namespace
    public class ListViewEx : ListView
    {
        #region Windows API
        [DllImport("User32.dll")]
        static extern int GetDlgCtrlID(IntPtr h_Wnd);
        /*
        struct MEASUREITEMSTRUCT 
        {
            public int    CtlType;     // Offset = 0
            public int    CtlID;       // Offset = 1
            public int    itemID;      // Offset = 2
            public int    itemWidth;   // Offset = 3
            public int    itemHeight;  // Offset = 4
            public IntPtr itemData;
        }
        */
        [StructLayout(LayoutKind.Sequential)]
        struct DRAWITEMSTRUCT
        {
            public int    ctlType;
            public int    ctlID;
            public int    itemID;
            public int    itemAction;
            public int    itemState;
            public IntPtr hWndItem;
            public IntPtr hDC;
            public int    rcLeft;
            public int    rcTop;
            public int    rcRight;
            public int    rcBottom;
            public IntPtr itemData;
        }
        // LVS_OWNERDRAWFIXED: The owner window can paint ListView items in report view. 
        // The ListView control sends a WM_DRAWITEM message to paint each item. It does not send separate messages for each subitem. 
        const int LVS_OWNERDRAWFIXED = 0x0400;
        const int WM_SHOWWINDOW      = 0x0018;
        const int WM_DRAWITEM        = 0x002B;
        const int WM_MEASUREITEM     = 0x002C;
        #endregion
        int ms32_CtrlID    = 0;
        int ms32_RowHeight = 14;
        /// <summary>
        /// Constructor
        /// </summary>
        public ListViewEx()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
        /// <summary>
        /// Sets the row height in Details mode
        /// This property appears in the Visual Studio Form Designer
        /// </summary>
        [Category("Appearance")]  
        [Description("Sets the height of the ListView rows in Details view in pixels.")] 
        public int RowHeight
        {
            get { return ms32_RowHeight; }
            set 
            { 
                Debug.Assert(ms32_CtrlID == 0, "RowHeight must be set before ListViewEx is created.");
                ms32_RowHeight = value; 
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams k_Params = base.CreateParams;
                k_Params.Style |= LVS_OWNERDRAWFIXED;
                return k_Params;
            }
        }
        /// <summary>
        /// This function must be called from the WndProc of the parent control that contains this ListView (Form, GroupBox, Panel,..)
        /// The messages WM_MEASUREITEM and WM_DRAWITEM are sent to the parent control rather than to the ListView itself.
        /// </summary>
        public void ReflectedWndProc(ref Message k_Msg)
        {
            switch (k_Msg.Msg)
            {
                case WM_SHOWWINDOW: // called when the parent control or Form becomes visible
                {
                    Debug.Assert(View == View.Details, "ListViewEx supports only Details view");
                    Debug.Assert(OwnerDraw == false,   "In ListViewEx do not set OwnerDraw = true");
                    break;
                }
                case WM_MEASUREITEM: // called once when the ListView is created, but only in Details mode
                {
                    ms32_CtrlID = GetDlgCtrlID(Handle);
                    if ((int)k_Msg.WParam != ms32_CtrlID)
                        break; // The message is for another control
                    // Overwrite itemHeight, which is the fifth integer in MEASUREITEMSTRUCT 
                    Marshal.WriteInt32(k_Msg.LParam + 4 * sizeof(int), ms32_RowHeight);
                    k_Msg.Result = (IntPtr)1;
                    break;
                }
                case WM_DRAWITEM: // called for each ListViewItem to be drawn
                {
                    if ((int)k_Msg.WParam != ms32_CtrlID)
                        break; // The message is for another control
                    DRAWITEMSTRUCT k_Draw = (DRAWITEMSTRUCT) k_Msg.GetLParam(typeof(DRAWITEMSTRUCT));
                    using (Graphics i_Graph = Graphics.FromHdc(k_Draw.hDC))
                    {
                        ListViewItem i_Item = Items[k_Draw.itemID];
                            
                        Color c_BackColor = i_Item.BackColor;
                        if (i_Item.Selected) c_BackColor = SystemColors.Highlight;
                        if (!Enabled)        c_BackColor = SystemColors.Control;
                        using (SolidBrush i_BackBrush = new SolidBrush(c_BackColor))
                        {
                            // Erase the background of the entire row
                            i_Graph.FillRectangle(i_BackBrush, i_Item.Bounds);
                        }
                        for (int S=0; S<i_Item.SubItems.Count; S++)
                        {
                            ListViewItem.ListViewSubItem i_SubItem = i_Item.SubItems[S];
                            // i_Item.SubItems[0].Bounds contains the entire row, rather than the first column only.
                            Rectangle k_Bounds = (S>0) ? i_SubItem.Bounds : i_Item.GetBounds(ItemBoundsPortion.Label);
                            // You can use i_Item.ForeColor instead of i_SubItem.ForeColor to get the same behaviour as without OwnerDraw
                            Color c_ForeColor = i_SubItem.ForeColor;
                            if (i_Item.Selected) c_ForeColor = SystemColors.HighlightText;
                            if (!Enabled)        c_ForeColor = SystemColors.ControlText;
                            TextFormatFlags e_Flags = TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
                            switch (Columns[S].TextAlign)
                            {
                                case HorizontalAlignment.Center: e_Flags |= TextFormatFlags.HorizontalCenter; break;
                                case HorizontalAlignment.Right:  e_Flags |= TextFormatFlags.Right; break;
                            }
                            TextRenderer.DrawText(i_Graph, i_SubItem.Text, i_SubItem.Font, k_Bounds, c_ForeColor, e_Flags);
                        }
                    }
                    break;
                }
            }
        }
    }
