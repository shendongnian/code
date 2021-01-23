    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Common
    {
        public class ListBoxEx : ListBox
        {
            public event ItemClickedEventHandler ItemClick;
            public event ItemClickedEventHandler ItemDoubleClick;
    
            /// <summary>
            /// Toggle selections when list has SelectionMode.One
            /// </summary>
            public bool ToggleSingleSelection { get; set; }
    
            int _PreSelectedIndex = -1;
            int _PrevClickedItem = -1;
    
            protected override void OnSelectedIndexChanged(EventArgs e)
            {
                base.OnSelectedIndexChanged(e);
            }
    
            protected override void WndProc(ref Message m)
            {
                const int WM_LBUTTONDOWN = 0x201;
                switch (m.Msg)
                {
                    case WM_LBUTTONDOWN:
                        // NOTE: Unfortunately SelectedIndex is already setted before OnMouseDown,
                        // so we must intercept mouse click even before to compare
                        _PreSelectedIndex = SelectedIndex;
                        break;
                }
    
                base.WndProc(ref m);
            }
    
            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);
    
                // Reset clicked event, also for double click
                _PrevClickedItem = -1;
                int selectedIndex = SelectedIndex;
                if (selectedIndex != -1)
                {
                    Rectangle selectedItemRectangle = GetItemRectangle(selectedIndex);
                    if (selectedItemRectangle.Contains(e.Location))
                    {
                        _PrevClickedItem = selectedIndex;
    
                        // Check when to toggle selection
                        if (SelectionMode == SelectionMode.One && ToggleSingleSelection && ModifierKeys.HasFlag(Keys.Control)
                            && _PreSelectedIndex != -1 && selectedIndex == _PreSelectedIndex)
                        {
                            SelectedIndex = -1;
                        }
    
                        if (_PrevClickedItem != -1)
                            OnItemClick(new ItemClickedEventArgs() { ItemIndex = _PrevClickedItem });
                    }
                }
            }
    
            protected override void OnMouseDoubleClick(MouseEventArgs e)
            {
                base.OnMouseDoubleClick(e);
    
                if (_PrevClickedItem != -1)
                    OnItemDoubleClick(new ItemClickedEventArgs() { ItemIndex = _PrevClickedItem });
            }
    
            protected virtual void OnItemDoubleClick(ItemClickedEventArgs args)
            {
                ItemDoubleClick?.Invoke(this, args);
            }
    
            protected virtual void OnItemClick(ItemClickedEventArgs args)
            {
                ItemClick?.Invoke(this, args);
            }
        }
    
        public class ItemClickedEventArgs : EventArgs
        {
            public int ItemIndex { get; set; }
        }
    
        public delegate void ItemClickedEventHandler(Control sender, ItemClickedEventArgs args);
    }
