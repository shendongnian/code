            private int xPos=0;
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (this.Width == xPos)
                {
                    //repeat marquee
                    this.lblMarquee.Location = new System.Drawing.Point(0, 40);
                    xPos = 0;
                }
                else
                {
                    this.lblMarquee.Location = new System.Drawing.Point(xPos, 40);
                    xPos++;
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Start();
            }
