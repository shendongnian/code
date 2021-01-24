        public Form1()
        {
            InitializeComponent();
            PICkitS.LIN.OnAnswer += new PICkitS.LIN.GUINotifierOA(LinDongle_OnAnswer);
            PICkitS.LIN.OnReceive += new PICkitS.LIN.GUINotifierOR(LinDongle_OnReceive);
        }
