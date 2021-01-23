    /// <summary>
    /// Fixes a known issue with the <see cref="RibbonGallery"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="https://connect.microsoft.com/VisualStudio/feedback/details/666352/">Allow users to move mouse after selecting an item in WPF RibbonComboBox</a>.
    /// </remarks>
    public class RibbonGalleryEx : RibbonGallery
    {
        public RibbonGalleryEx()
        {
            this.SelectionChanged += (sender, e) => Mouse.Capture(null);
        }
    }
