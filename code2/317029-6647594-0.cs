    public Form1()
    {
        InitializeComponent();
        UserControl1 test = new UserControl1();
        test.BackColor = Color.Transparent;
        test.Location = new Point(0, 110);
        test.Width = 660;
        test.Height = 478;
        PictureBox b = new PictureBox();
        b.Location = new Point(100, 100);
        b.Width = 320;
        b.Height = 475;
        b.Image = Properties.Resources.movie;
        test.Controls.Add(b);
        this.Controls.Add(test);//<- here
    }
