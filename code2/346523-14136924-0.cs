    using System.Windows.Controls;
    /// <summary>
    /// A list box which automatically scrolls to the last line if new items were added.
    /// </summary>
    public class AutoscrollListBox : ListBox
    {
        /// <summary>
        /// The on items changed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.ScrollDown();
            base.OnItemsChanged(e);
        }
        /// <summary>
        /// Scrolls to the last element.
        /// </summary>
        private void ScrollDown()
        {
            if (this.Items.Count > 0)
            {
                var lastItem = this.Items[this.Items.Count - 1];
                this.ScrollIntoView(lastItem);
            }
        }
    }
