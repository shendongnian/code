     private Panel[] _panels = new Panel[10];
     public Form1()
        {
            InitializeComponent();               
    
            for (int i=0;i<10;i++)
            {
                //Panel newPanel = new Panel();
                _panels[i] = new Panel();
                _panels[i].Size = new Size(40, 37);
                _panels[i].BackgroundImage = imageList1.Images[0];
                _panels[i].Location = new Point(i * 20, i * 20);
                this.Controls.Add(_panels[i]);
            }
    
        }
