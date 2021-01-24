    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //base.OnMouseMove(e);
            //Point p = Cursor.Position;
            //label1.Text = "x= " + p.X.ToString();
            //label2.Text = "y= " + p.Y.ToString();
            label1.Text = "x= " + e.X.ToString();
            label2.Text = "y= " + e.Y.ToString();        
        }
