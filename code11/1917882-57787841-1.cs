    public static void PasteFilesFromClipboard(string aTargetFolder)
    {
        var aFileDropList = Clipboard.GetFileDropList();
        if (aFileDropList == null || aFileDropList.Count == 0) return;
        bool aMove = false;
        var aDataDropEffect = Clipboard.GetData("Preferred DropEffect");
        if (aDataDropEffect != null)
        {
                MemoryStream aDropEffect = (MemoryStream)aDataDropEffect;
                byte[] aMoveEffect = new byte[4];
                aDropEffect.Read(aMoveEffect, 0, aMoveEffect.Length);
                var aDragDropEffects = (DragDropEffects)BitConverter.ToInt32(aMoveEffect, 0);
                aMove = aDragDropEffects.HasFlag(DragDropEffects.Move);
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
