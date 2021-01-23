        private void zoomSlider_Scroll(object sender, EventArgs e)
        {
        if ((zoomSlider.Value > 0) && (imgOriginal != null))
            {
            picBox.Image = null;
            picBox.Image = PictureBoxZoom(imgOriginal, new Size(zoomSlider.Value, zoomSlider.Value));
            }
        }
