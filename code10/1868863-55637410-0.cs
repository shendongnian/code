    private void pictureBox1_Click(object sender, EventArgs e)
    {
        pictureBox1.BorderStyle = BorderStyle.None;
        pictureBox2.BorderStyle = BorderStyle.None;
        pictureBox3.BorderStyle = BorderStyle.None;
        pictureBox4.BorderStyle = BorderStyle.None;
        PictureBox p = (PictureBox)sender;
        pen.Color = p.BackColor;
        p.BorderStyle = BorderStyle.Fixed3D;
    }
