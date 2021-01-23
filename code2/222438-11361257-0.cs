    public class DraggableTabControl : TabControl
    {
        private TabPage m_DraggedTab;
        public DraggableTabControl()
        {
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            m_DraggedTab = TabAt(e.Location);
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || m_DraggedTab == null)
            {
                return;
            }
            TabPage tab = TabAt(e.Location);
            if (tab == null || tab == m_DraggedTab)
            {
                return;
            }
            Swap(m_DraggedTab, tab);
            SelectedTab = m_DraggedTab;
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
    }
