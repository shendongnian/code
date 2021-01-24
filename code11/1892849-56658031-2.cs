    foreach (PictureBox pb in Controls.OfType<PictureBox>())
    {
        pb.Image = Properties.Resorces.available;
        pb.Click += PictureBox_Click;  // Defined below
    }
