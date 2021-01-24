    private async void button2_Click(object sender, EventArgs e)
    {
        var bitmap = await Task.Run(() =>
        {
            return (Bitmap)Image.FromFile(@"C:\Users...\1.jpg");
        });
        pictureBox1.Image = bitmap;
        var result = await Task.Run(() =>
        {
            var decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            return decoder.Decode(new QRCodeBitmapImage(bitmap));
        });
        textBox2.Text = result;
    }
