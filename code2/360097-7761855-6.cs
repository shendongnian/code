        public Form1()
        {
            InitializeComponent();
            dinnerFun = new DinnerFun { PeepQty = (int)nudPeepQty.Value }; 
            // ^^^ instantiates class field
        }
