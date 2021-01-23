            // 
            // pictureBox1 Init
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
..........................................
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));
        }
