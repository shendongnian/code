    void picturebox_Paint(object sender, PaintEventArgs e)
    {
        int a = picturebox.Width - picturebox.Image.Width;
        int b = picturebox.Height - picturebox.Image.Height;
        Padding p = new System.Windows.Forms.Padding();
        p.Left = a / 2;
        p.Top = b / 2;
        picturebox.Padding = p;
    }
