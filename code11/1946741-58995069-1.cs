    private async void button2_Click(object sender, EventArgs e)
        {
            var Result = await Decode("Image Path");
            textBox2.Text = Result;
        }
        private async Task<string> Decode(string PathOfImage)
        {
            var DecodedText = string.Empty;
            var decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            await Task.Run(() =>
            {
                var Image = = Image.FromFile(PathOfImage);
                DecodedText = decoder.Decode(new QRCodeBitmapImage(Image as Bitmap));
            });
            return DecodedText;
        }
