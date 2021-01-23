    private void button1_Click(object sender, EventArgs e)
    {
        const int AW_HIDE = 0x00010000;
        const int AW_SLIDE = 0x00040000;
        const int AW_HOR_NEGATIVE = 0x00000002;
        AnimateWindow(pictureBox1.Handle, 1000, AW_HIDE | AW_SLIDE | AW_HOR_NEGATIVE);
    }
