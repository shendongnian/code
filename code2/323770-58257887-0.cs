        public string imageFilePath = null;
        public string textOnImage = null;
        public Image baseImage;
        public Image modifiedImage;
        public int xcoOrdinate = 0;
        public int ycoOrdinate = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog uploadfileDialog = new OpenFileDialog();
                uploadfileDialog.Filter = "All Files (*.*)|*.*";
                uploadfileDialog.Multiselect = false;
                if (uploadfileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFilePath = uploadfileDialog.FileName;
                }
                baseImage = Image.FromFile(imageFilePath);
                modifiedImage = (Image)baseImage.Clone();
                pictureBoxToShowPic.Image = baseImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " : " + ex.Message);
            }            
        }
        public void paint()
        {
            try
            {
                Graphics g = Graphics.FromImage(modifiedImage);
                using (Font myfont = new Font("Arial", 14))
                {
                    var format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(textOnImage, myfont, Brushes.Black, new Point(xcoOrdinate, ycoOrdinate), format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " : " + ex.Message);
            }
        }
        private void buttonAddText_Click(object sender, EventArgs e)
        {
            try
            {
                textOnImage = textBoxWriteText.Text;
                paint();
                pictureBoxToShowPic.Image = modifiedImage;
                pictureBoxToShowPic.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " : " + ex.Message);
            }
        }
        
        private void pictureBoxToShowPic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                xcoOrdinate = e.X;
                ycoOrdinate = e.Y;
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " : " + ex.Message);
            }
        }
        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefileDialog = new SaveFileDialog();
                savefileDialog.Filter = "Images|*.jpg ; *.png ; *.bmp";
                if (savefileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFilePath = savefileDialog.FileName;
                }
                modifiedImage.Save(imageFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " : " + ex.Message);
            }
        }
