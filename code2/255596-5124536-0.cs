        private void timer1_Tick(object sender, EventArgs e) {
            var frm = Form.ActiveForm;
            using (var bmp = new Bitmap(frm.Width, frm.Height)) {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"c:\temp\screenshot.png");
            }
        }
