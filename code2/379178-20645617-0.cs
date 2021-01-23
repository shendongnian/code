    public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Left, Screen.PrimaryScreen.WorkingArea.Top);
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                pictureBox1.Size = new Size(this.Width - this.Width / 2, this.Height - this.Height / 2);
                pictureBox1.Location = new Point(0, 0);
                pictureBox2.Size = new Size(this.Width - this.Width / 2, this.Height - this.Height / 2);
                pictureBox2.Location = new Point(this.pictureBox1.Width,0);
                pictureBox3.Size = new Size(this.Width - this.Width / 2, this.Height - this.Height / 2);
                pictureBox3.Location = new Point(0, this.pictureBox1.Height);
                pictureBox4.Size = new Size(this.Width - this.Width / 2, this.Height - this.Height / 2);
                pictureBox4.Location = new Point(this.pictureBox2.Width, this.pictureBox3.Height);
                // this.Controls.Add(pictureBox1);
            }
        }
    }
