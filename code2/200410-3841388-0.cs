        private UserControl currentView;
        public void SelectView(UserControl ctl) {
            if (currentView != null) {
                panel1.Controls.Remove(currentView);
                currentView.Dispose();
            }
            if (ctl != null) {
                ctl.Dock = DockStyle.Fill;
                panel1.Controls.Add(ctl);
            }
            currentView = ctl;
        }
