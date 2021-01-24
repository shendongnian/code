    private async void button2_Click(object sender, EventArgs e)
        {
            var DecodedText = string.Empty;
            var decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            await Task.Run(() => {
                DecodedText = decoder.Decode(new QRCodeBitmapImage(Image.FromFile(PathOfImage) as Bitmap));
            });
            textBox2.Text = DecodedText;
        }
