        /// <summary>
        /// Gets whether any cell on this item is showing a hyperlink
        /// </summary>
        public bool HasAnyHyperlinks {
            get {
                foreach (OLVListSubItem subItem in this.SubItems) {
                    if (!String.IsNullOrEmpty(subItem.Url))
                        return true;
                }
                return false;
            }
        }
Only invocation in the codebase seems to be in `PostProcessOneRow` in ObjectListView.cs (this matches your stack trace).
The caller line is:
            if (this.UseHyperlinks && olvi.HasAnyHyperlinks) {
                PropagateFormatFromRowToCells(olvi);
                this.ApplyHyperlinkStyle(olvi);
So you could probably avoid this issue by setting `UseHyperlinks` to false (if you don't have any).  
Alternatively you could put a try/catch around where you are calling SetObjects and try again (assuming your stack trace had some proprietary frames that you dropped out).  
Finally `ObjectListView.PostProcessOneRow` is virtual so you could solve it by subclassing ObjectListView and write custom implementation (talk about over engineering though).
