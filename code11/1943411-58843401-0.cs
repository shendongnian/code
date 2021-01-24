        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image!=null&& getSignatureLen( pictureBox1.Image) == getSignatureLen(Properties.Resources.openeye))
            {
                pictureBox1.Image = Properties.Resources.closeeye;
            }
            else
            {
                pictureBox1.Image = PProperties.Resources.openeye;
            }
        }
        public long  getSignatureLen(Image img)
        {
            using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.Length;
            }
        }
