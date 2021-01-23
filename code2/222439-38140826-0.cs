    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace Controls
    {
        public class DraggableTabControl : TabControl
        {
            private TabPage draggedTab;
            public DraggableTabControl()
            {
                this.MouseDown += OnMouseDown;
                this.MouseMove += OnMouseMove;
                this.Leave += new System.EventHandler(this.DraggableTabControl_Leave);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            }
            private void OnMouseDown(object sender, MouseEventArgs e)
            {
                draggedTab = TabAt(e.Location);
            }
            private void OnMouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left || draggedTab == null)
                {
                    this.Cursor = this.DefaultCursor;
                    return;
                }
                int index = TabPages.IndexOf(draggedTab);          
                int nextIndex = index + 1;
                int prevIndex = index - 1;
                int minXForNext = int.MaxValue;
                int maxXForPrev = int.MinValue;
                var tabRect = GetTabRect(index);
                if (nextIndex < TabPages.Count)
                {
                    var nextTabRect = GetTabRect(nextIndex);
                    minXForNext = tabRect.Left + nextTabRect.Width;
                }
                if (prevIndex >= 0)
                {
                    var prevTabRect = GetTabRect(prevIndex);
                    maxXForPrev = prevTabRect.Left + tabRect.Width;
                }
                this.Cursor = Cursors.Hand;
                if (e.Location.X > maxXForPrev && e.Location.X < minXForNext)
                {
                    return;
                }
                TabPage tab = TabAt(e.Location);
                if (tab == null || tab == draggedTab)
                {
                    return;
                }
                Swap(draggedTab, tab);
                SelectedTab = draggedTab;
            }
            private TabPage TabAt(Point position)
            {
                int count = TabCount;
                for (int i = 0; i < count; i++)
                {
                    if (GetTabRect(i).Contains(position))
                    {
                        return TabPages[i];
                    }
                }
                return null;
            }
            private void Swap(TabPage a, TabPage b)
            {
                int i = TabPages.IndexOf(a);
                int j = TabPages.IndexOf(b);
                TabPages[i] = b;
                TabPages[j] = a;
            }
            private void DraggableTabControl_Leave(object sender, EventArgs e)
            {
                this.Cursor = this.DefaultCursor;
            }
        }
    }
