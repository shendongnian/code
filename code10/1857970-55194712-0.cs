private void BtnOk_Click(object sender, EventArgs e)
{
    if (picCapturedImage.Image != null)
    {
        var bitmap = new Bitmap(picCapturedImage.Image);
        var newBitmap = new Bitmap(bitmap);
        for (int i = 0; i < int.MaxValue; i++)
        {
            var fileName = @$"..\..\Resources\Image{i}.png";
            if (File.Exists(fileName))
            {
                continue;
            }
            else
            {
                bitmap.Save(fileName, ImageFormat.Png);
            }
        }
        bitmap.Dispose();
        bitmap = null;
    }
    Close();
}
