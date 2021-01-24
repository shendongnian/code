    public Form1(List<Basket> theList)
        {
            InitializeComponent();
            foreach(Basket e in stheListas)
            {
                basketBox.Text += e.Name + Environment.NewLine;
            }
        }
