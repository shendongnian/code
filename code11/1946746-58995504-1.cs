    private async void button2_Click(object sender, EventArgs e)
    {
        pictureBox1.Image = Image.FromFile(@"C:\Users...\1.jpg");
        var bitmap = pictureBox1.Image as Bitmap;
        var result = await Task.Run(() =>
        {
            var decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            return decoder.Decode(new QRCodeBitmapImage(bitmap));
        });
        textBox2.Text = result;
    }
