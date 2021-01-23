    public class ScrollableDataGrid : DataGrid
    {
        private IScrollProvider m_scrollProvider;
        public ScrollableDataGrid()
        {
            m_scrollProvider = OnCreateAutomationPeer() as IScrollProvider;
        }
        public void ScrollToBottom()
        {
            while (m_scrollProvider.VerticalScrollPercent < 100)
            {
                m_scrollProvider.Scroll(ScrollAmount.NoAmount, ScrollAmount.LargeIncrement);
            }
        }
    }
