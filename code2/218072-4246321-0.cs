        private string _currentTool;
        private void Button1_Click(object sender, EventArgs e)
        {
            _currentTool = "img";
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentTool)
            {
                case "img":
                    Graphics g = pictureBox1.CreateGraphics();
                    g.DrawImage(button1.Image, e.X, e.Y);
                    break;
            }
        }
