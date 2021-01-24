    public CustomForm(List<Basket> theList)
        {
            InitializeComponent();
            foreach(Basket e in theList)
            {
                basketBox.Text += e.Name + Environment.NewLine;
            }
        }
