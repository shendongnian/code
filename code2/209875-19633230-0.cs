    static class ClearClipboardFormat
    {        
        public static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            e.FormatToApply = DataFormats.Text;            
        }
    }
