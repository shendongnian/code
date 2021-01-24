        private void BrowseImage_Click(object sender, EventArgs e)
        {
            DrinkView.Image.Dispose();
            var imagePath = image.BROWSEIMAGE();
            if (imagePath.Length > 10)
            {
                DrinkView.Image = new Bitmap(imagePath);
                imagepath.Text = imagePath;
            }
        }
