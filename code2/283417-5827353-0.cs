    private void Form_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WmNcLButtonDown, HtCaption, 0);
        }
    }
