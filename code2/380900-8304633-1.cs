      PictureBox pbox1 = new PictureBox();
      Point[] path = { new Point(10,100), new Point(150, 60), new Point(100, 120)};
      Timer timer1 = new Timer();
      int curPointIndex = 0;
      int nextPointIndex = 1;
      float percent = 0f;
      float pctIncrement = 1f;
      public Form1()
      {
         InitializeComponent();
         pbox1.Location = path[0];
         pbox1.Size = new Size(32, 32);
         pbox1.BackColor = Color.Red;
         timer1.Interval = 20;
         timer1.Tick += new EventHandler(timer1_Tick);
         timer1.Start();
         this.Controls.Add(pbox1);
         this.components.Add(timer1);
      }
      void timer1_Tick(object sender, EventArgs e)
      {
         percent += pctIncrement;
         // Calculate weighted average based on point number
         // curPointIndex and nextPointIndex in path here.
         // Set pbox1.Location to calculated position here.
         // Check for altering curPointIndex and nextPointIndex here when percent
         // reaches 100 (and reset percent) here.
      }
