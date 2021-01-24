    public async void Capture_Click(object sender, EventArgs args)
    {
        while(someCondition)
        {
            await Task.Run(()=>m_camera.GrabImage();
            SaveImage();
            var copyBmp = (Bitmap)mImage.bmp.Clone();
            pictureBox1.Image = copyBmp;
            m_camera.ReleaseImage();
        }
    }
