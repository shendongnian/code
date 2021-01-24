    protected override void OnMouseMove(MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left && canMovePictureBox)
        {
            this.Left += e.X - point.X;
            this.Top += e.Y - point.Y;
        }
    }
