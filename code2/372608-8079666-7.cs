    private void button1_Click(object sender, EventArgs e)
    {
       const int AW_HIDE = 0x00010000;
       const int AW_SLIDE = 0x00040000;
       const int AW_HOR_NEGATIVE = 0x00000002;
       const int AW_HOR_POSITIVE = 0x00000001;
       // Toggle show/hide
       AnimateWindow(pictureBox1.Handle, 1000, (pictureBox1.Visible ^= true) ? (AW_HIDE | AW_HOR_NEGATIVE) : (AW_HOR_POSITIVE) | AW_SLIDE);
    }
