        private void SampleLoadPicture(string fileName)
        {
            var imageDate = ImageDate.Load(fileName);
            // Store in a database:
            // imageDate.CapturedImage;
            // imageDate.CapturedDateTime;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var imageDate = new ImageDate((Bitmap)pictureBox1.Image, DateTime.Now);
            imageDate.Save(pictureCount.ToString() + ".IMGDATE");
            pictureCount++;
        }
        [Serializable]
        public class ImageDate
        {
            public Bitmap CapturedImage { get; set; }
            public DateTime CapturedDateTime { get; set; }
            public void Save(string fileName)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, this);
                }
            }
            public static ImageDate Load(string fileName)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (ImageDate)formatter.Deserialize(fs);
                }
            }
            public ImageDate() { }
            public ImageDate(Bitmap capturedImage, DateTime capturedDateTime)
            {
                CapturedImage = capturedImage;
                CapturedDateTime = capturedDateTime;
            }
        }
