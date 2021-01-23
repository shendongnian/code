            try
            {
                this.Hide();
                Thread.Sleep(250);
                bmpScreenshot = new Bitmap(this.Bounds.Width, this.Bounds.Height, PixelFormat.Format32bppArgb);
                gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(this.Bounds.X, this.Bounds.Y, 0, 0, this.Bounds.Size, CopyPixelOperation.SourceCopy);
                bmpScreenshot.Save(SaveLocation, ImageFormat.Png);
                tbxStatus.AppendText(Environment.NewLine);
                tbxStatus.AppendText(Environment.NewLine);
                tbxStatus.AppendText("Screenshot saved at " + SaveLocation);
                numSuffix++;
            }
            catch (Exception ex)
            {
                tbxStatus.AppendText(Environment.NewLine);
                tbxStatus.AppendText(Environment.NewLine);
                tbxStatus.AppendText("Unable to take screenshot. Exception: " + ex.ToString());
            }
            finally
            {
                this.Show();
            }
