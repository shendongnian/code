    private void CameraControl1_Paint(object sender, PaintEventArgs e)
    {
        CameraControl c = sender as CameraControl;
        if (isStopped && img != null)
             e.Graphics.DrawImage(img, new Rectangle(0,0, c.Width, c.Height));
    }
    bool isStopped = false;
    Bitmap img;
    private void button1_Click(object sender, EventArgs e)
    {
        img = cameraControl1.TakeSnapshot();
        cameraControl1.Stop();
        isStopped = true;
    }
