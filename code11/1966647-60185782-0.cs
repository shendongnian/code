                for (int x = 0; x < flt.GetLength(2); x++)
                {
                    if (flt[0, 0, x, 2] > 0.1)
                    {
                        int left = Convert.ToInt32(flt[0, 0, x, 3] * cols);
                        int top = Convert.ToInt32(flt[0, 0, x, 4] * rows);
                        int right = Convert.ToInt32(flt[0, 0, x, 5] * cols);
                        int bottom = Convert.ToInt32(flt[0, 0, x, 6] * rows);
                        image1.Draw(new Rectangle(left, top, right - left, bottom - top), new Bgr(0, 0, 255), 2);
                    }
                }
And finally, we can save that image:
image1.Save("testing-1.png");
So, the result code wil look like:
            using (Image<Bgr, byte> image1 = new Image<Bgr, byte>("testing.png"))
            {
                int interception = 0;
                int cols = image1.Width;
                int rows = image1.Height;
                Net netcfg = DnnInvoke.ReadNetFromTensorflow(Directory.GetCurrentDirectory() + @"\fldr\CO.pb", Directory.GetCurrentDirectory() + @"\fldr\graph.pbtxt");
                netcfg.SetInput(DnnInvoke.BlobFromImage(image1.Mat, 1, new System.Drawing.Size(300, 300), default(MCvScalar), true, false));
                Mat mat = netcfg.Forward();
                float[,,,] flt = (float[,,,])mat.GetData();
                for (int x = 0; x < flt.GetLength(2); x++)
                {
                    if (flt[0, 0, x, 2] > 0.1)
                    {
                        int left = Convert.ToInt32(flt[0, 0, x, 3] * cols);
                        int top = Convert.ToInt32(flt[0, 0, x, 4] * rows);
                        int right = Convert.ToInt32(flt[0, 0, x, 5] * cols);
                        int bottom = Convert.ToInt32(flt[0, 0, x, 6] * rows);
                        image1.Draw(new Rectangle(left, top, right - left, bottom - top), new Bgr(0, 0, 255), 2);
                    }
                }
                image1.Save("testing-1.png");
            }
