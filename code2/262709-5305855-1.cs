        public Form1() {
            InitializeComponent();
    #if !SERVERBUILD
            panel1.Visible = false;
    #endif
        }
