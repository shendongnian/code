    private void btnLoadImage_Click(object sender, EventArgs e)
        {
            imageList1.Images.Clear();
            if (openFDialogImage.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFDialogImage.FileNames.Length; i++)
                {
                        
    imageList1.Images.Add(Image.FromFile(openFDialogImage.FileNames[i]));
                }
                pictureBox1.Image = imageList1.Images[currentIndex];
            }
        }
        private void BtnForward_Click(object sender, EventArgs e)
        {
            if(currentIndex!=imageList1.Images.Count-1 && imageList1.Images.Count > 0)
            {
                pictureBox1.Image = imageList1.Images[currentIndex++];
            }
            
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentIndex!=0)
            {
                pictureBox1.Image = imageList1.Images[--currentIndex];
            }
        }
