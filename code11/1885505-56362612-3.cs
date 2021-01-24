    float GetFactor(PictureBox pBox)
    {
        if (pBox.Image == null) return 0;
        Size si = pBox.Image.Size;
        Size sp = pBox.ClientSize;
        float ri = 1f * si.Width / si.Height;
        float rp = 1f * sp.Width / sp.Height;
        float factor = 1f * pBox.Image.Width / pBox.ClientSize.Width;
        if (rp > ri) factor = 1f * pBox.Image.Height / pBox.ClientSize.Height;
        return factor;
    }
