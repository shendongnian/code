    private async void button2_Click(object sender, EventArgs e)
    {
        var result = await Task.Run(() =>
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users...\1.jpg");
            var decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            return decoder.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
        });
        textBox2.Text = result;
    }
