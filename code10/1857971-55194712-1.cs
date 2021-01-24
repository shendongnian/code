private void BtnOk_Click(object sender, EventArgs e)
{
    if (picCapturedImage.Image != null)
    {
        using (var bitmap = new Bitmap(picCapturedImage.Image))
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                var fileName = @$"..\..\Resources\Image{i}.png";
                if (!File.Exists(fileName))
                {
                    bitmap.Save(fileName, ImageFormat.Png);
                    break;
                }
            }
        }
    }
    Close();
}
