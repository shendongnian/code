    public static void PasteFilesFromClipboard(string aTargetFolder)
    {
        var aFileDropList = Clipboard.GetFileDropList();
        if (aFileDropList == null || aFileDropList.Count == 0) return;
        bool aMove = false;
        var aDataDropEffect = Clipboard.GetData("Preferred DropEffect");
        if (aDataDropEffect != null)
        {
            MemoryStream dropEffect = (MemoryStream)aDataDropEffect;
            byte[] moveEffect = new byte[4];
            dropEffect.Read(moveEffect, 0, moveEffect.Length);
            aMove = moveEffect[0] == 2;
        }
        foreach (string aFileName in aFileDropList)
        {
            if (aMove) { } // Move File ...
            else { } // Copy File ...
        }
    }
    [Flags]
    public enum DragDropEffects
    {
        Scroll = int.MinValue,
        All = -2147483645,
        None = 0,
        Copy = 1,
        Move = 2,
        Link = 4
    }
