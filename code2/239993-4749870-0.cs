        Random rand = new Random();
        private void timer1_Tick(object sender, EventArgs e) {
            using (var bmp = new Bitmap(1, 1)) {
                using (var gr = Graphics.FromImage(bmp)) {
                    gr.CopyFromScreen(rand.Next(800), rand.Next(600), 0, 0, new Size(1, 1));
                    Console.WriteLine(bmp.GetPixel(0, 0).ToString());
                }
            }
        }
