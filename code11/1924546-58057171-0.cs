    public partial class FormTabsAlternative
        : Form
    {
        int         m_current = 0;
        List<Panel> m_tabs    = new List<Panel>();
        public FormTabsAlternative()
        {
            InitializeComponent();
            AddTab(pnl1);
            AddTab(pnl2);
            AddTab(pnl3);
            AddTab(pnl4);
            SetUpTabsAndButtons();
        }
        private void AddTab(Panel pnl)
        {
            m_tabs.Add(pnl);
            pnl.Dock = DockStyle.Fill;
        }
        private void OnLeftClick(object sender, EventArgs e)
        {
            if (m_current > 0)
            {
                m_current--;
                SetUpTabsAndButtons();
            }
        }
        private void OnRightClick(object sender, EventArgs e)
        {
            if (m_current < m_tabs.Count - 1)
            {
                m_current++;
                SetUpTabsAndButtons();
            }
        }
        private void SetUpTabsAndButtons()
        {
            for (int index = 0; index < m_tabs.Count; index++)
            {
                var panel     = m_tabs[index];
                panel.Visible = index == m_current;
            }
            btnLeft .Enabled = m_current > 0;
            btnRight.Enabled = m_current < m_tabs.Count - 1;
        }
    }
