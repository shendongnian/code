    class SceneManager
    {
        public Panel MainGamePanel { private get; set; }
        public Panel WinPanel { private get; set; }
        public SceneManager(Panel MainGamePanel, Panel WinPanel)
        {
            this.MainGamePanel = MainGamePanel;
            this.WinPanel = WinPanel;
        }
        public void ShowWinPanel()
        {
            MainGamePanel.Hide();
            WinPanel.Show();
        }
    }
