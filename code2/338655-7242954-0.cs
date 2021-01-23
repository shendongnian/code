    OpenFileDialog OpenFile = new OpenFileDialog();
    
    if (OpenFileDialog.ShowDialog() == DialogResult.OK)
    {
        Image<Bgr, byte> image = new Image<Bgr, byte>(OpenFile.FileName);
                
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        if (image.Data[j, i, 0] != 255)
                        {
                            Image<Bgr, byte> image_copy = image.Copy();
                            Image<Gray, byte> mask = new Image<Gray, byte>(image.Width + 2, image.Height + 2);
                            MCvConnectedComp comp = new MCvConnectedComp();
                            Point point1 = new Point(i, j);
                            //CvInvoke.cvFloodFill(
                            CvInvoke.cvFloodFill(image_copy.Ptr, point1, new MCvScalar(255, 255, 255, 255),
                            new MCvScalar(0, 0, 0),
                            new MCvScalar(0, 0, 0), out comp,
                            Emgu.CV.CvEnum.CONNECTIVITY.EIGHT_CONNECTED,
                            Emgu.CV.CvEnum.FLOODFILL_FLAG.DEFAULT, mask.Ptr);
                            if (comp.area < 10000)
                            {
                                image = image_copy.Copy();
                            }
                        }
                    }
                }
    }
