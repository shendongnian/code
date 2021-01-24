    private void BtnOk_Click(object sender, EventArgs e)
        {
            if (picCapturedImage.Image != null)
            {
                var bitmap = new Bitmap(picCapturedImage.Image);
                var newBitmap = new Bitmap(bitmap);
                string imageName=@"..\..\Resources\"+ "-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fff")+".Png"
                bitmap.Save(imageName, ImageFormat.Png);
    
                bitmap.Dispose();
                bitmap = null;
            }
    
    
            Close();
        }
