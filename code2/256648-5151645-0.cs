        public Form1() {
            InitializeComponent();
            var button = new Button();
            button.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(button);
            tableLayoutPanel1.SetCellPosition(button, new TableLayoutPanelCellPosition(0, 1));
            tableLayoutPanel1.SetColumnSpan(button, 2);
        }
