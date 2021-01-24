    foreach (PictureBox pb in Controls.OfType<PictureBox>())
    {
        pb.Image = Properties.Resorces.available;
        pb.Click += Pb_Click;  // Defined below
    }
