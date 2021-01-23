        [Serializable]
        private class Clipdata {
            public Image Image { get; set; }
            public string Name { get; set; }
        }
        private void CopyButton_Click(object sender, EventArgs e) {
            var data = new Clipdata { Image = pictureBox1.Image, Name = textBox1.Text };
            Clipboard.SetDataObject(data);
        }
        private void PasteButton_Click(object sender, EventArgs e) {
            string fmt = typeof(Clipdata).FullName;
            if (Clipboard.ContainsData(fmt)) {
                var data = (Clipdata)Clipboard.GetDataObject().GetData(fmt);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = data.Image;
                textBox1.Text = data.Name;
            }
        }
