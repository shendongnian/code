      Private void pictureBox_Paint(object sender, PaintEventArgs e) {
            Rectangle ee = new Rectangle(10, 10, 30, 30);           
            using (Pen pen = new Pen(Color.Red, 2)) {
                e.Graphics.DrawRectangle(pen, ee);
            }
      }
