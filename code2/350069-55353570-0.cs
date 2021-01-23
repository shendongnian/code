    public void Capture_Image()
        {
            try
            {
                capture.Start();
                capture.Pause();
                tempImg = capture.QueryFrame().Bitmap;//Capture twice here
                tempImg = capture.QueryFrame().Bitmap;
                tempImg.Save("C:/FHT59N3/Bildanalyse_Projekt/image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (NullReferenceException)
            {
                string message = "No Camera found";
                string title = "Please connect Camera";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }
