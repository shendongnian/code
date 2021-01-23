    using System.Windows;
    public class ClipboardService : IClipboardService
    {
        public void SetText(string value)
        {
            Clipboard.SetText(value);
        }
        public string GetText()
        {
            return Clipboard.GetText();
        }
    }
