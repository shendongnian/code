    public class CheckedListBoxDisabledItems : CheckedListBox {
        private List<string> _checkedAndDisabledItems = new List<string>();
        private List<int> _checkedAndDisabledIndexes = new List<int>();
        public void CheckAndDisable(string item) {
            _checkedAndDisabledItems.Add(item);
            this.Refresh();
        }
        public void CheckAndDisable(int index) {
            _checkedAndDisabledIndexes.Add(index);
            this.Refresh();
        }
        protected override void OnDrawItem(DrawItemEventArgs e) {
            string s = Items[e.Index].ToString();
            if (_checkedAndDisabledItems.Contains(s) || _checkedAndDisabledIndexes.Contains(e.Index)) {
                System.Windows.Forms.VisualStyles.CheckBoxState state = System.Windows.Forms.VisualStyles.CheckBoxState.CheckedDisabled;
                Size glyphSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);
                CheckBoxRenderer.DrawCheckBox(
                    e.Graphics,
                    new Point(e.Bounds.X + 1, e.Bounds.Y + 1), // add one pixel to align the check gliph properly
                    new Rectangle(
                        new Point(e.Bounds.X + glyphSize.Width + 3, e.Bounds.Y), // add three pixels to align text properly
                        new Size(e.Bounds.Width - glyphSize.Width, e.Bounds.Height)),
                    s,
                    this.Font,
                    TextFormatFlags.Left, // text is centered by default
                    false,
                    state); 
            }
            else {
                base.OnDrawItem(e);
            }
        }
        public void ClearDisabledItems() {
            _checkedAndDisabledIndexes.Clear();
            _checkedAndDisabledItems.Clear();
            this.Refresh();
        }
    }
