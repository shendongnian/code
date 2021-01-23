    SaveFileDialog bfsd = new SaveFileDialog();       
    var rtb = richTextBox1;
            bfsd.Filter = "Bitmap (*.bmp)|*.bmp|All Files (*.*)|*.*";
            bfsd.Title = "Save your text as a Bitmap File";
            rtb.Update(); // Ensure RTB fully painted
            Bitmap bmp = new Bitmap(rtb.Width, rtb.Height);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.CopyFromScreen(rtb.PointToScreen(Point.Empty), Point.Empty, rtb.Size);
            }
            if (bfsd.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    bmp.Save(bfsd.FileName);
                    bmp.Dispose();
                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("An error ocurred while attempting to save your Image...", "Error! Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (dr == DialogResult.Retry)
                    {
                        drawToBitmapbmpToolStripMenuItem_Click(sender, e);
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
