    private bool _once = true;
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (_once)
                {
                    Rectangle ee = new Rectangle(10, 10, 30, 30);
                    using (Pen pen = new Pen(Color.Red, 2))
                    {
                        e.Graphics.DrawRectangle(pen, ee);
                    }
                    _once = false;
                }
            }
