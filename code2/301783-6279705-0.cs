    private string GetSelectedItem()
    {
        string item = null;
        IntPtr pStringBuffer = Marshal.AllocHGlobal(2048);
        IntPtr pItemBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(LVITEM)));
        int selectedItemIndex = SendMessage(base.Handle, LVM_GETNEXTITEM, (IntPtr)(-1), (IntPtr)LVNI_SELECTED).ToInt32();
        if (selectedItemIndex > -1)
        {
            LVITEM lvi = new LVITEM();
            lvi.cchTextMax = 1024;
            lvi.pszText = pStringBuffer;
            Marshal.StructureToPtr(lvi, pItemBuffer, false);
            int numChars = SendMessage(base.Handle, LVM_GETITEMTEXT, (IntPtr)selectedItemIndex, pItemBuffer).ToInt32();
            if (numChars > 0)
            {
                item = Marshal.PtrToStringUni(lvi.pszText, numChars);
            }
        }
        Marshal.FreeHGlobal(pStringBuffer);
        Marshal.FreeHGlobal(pItemBuffer);
        return item;
    }
    struct LVITEM
    {
        public int mask;
        public int iItem;
        public int iSubItem;
        public int state;
        public int stateMask;
        public IntPtr pszText;
        public int cchTextMax;
        public int iImage;
        public IntPtr lParam;
        public int iIndent;
        public int iGroupId;
        int cColumns; // tile view columns
        public IntPtr puColumns;
        public IntPtr piColFmt;
        public int iGroup;
    }
