            private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ToolTip tooltip1 = new ToolTip();
            tooltip1.Show(textBox1.Text, this.pictureBox1);
        }
        
          private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();
        }
         
