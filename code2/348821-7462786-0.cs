            Bitmap bmp = ImageManipulator.GetMyImageModified(bmp);
            var t = new Thread(() => {
                try {
                    using (var croppedBmp = ImageManipulator.cropImage(bmp, rect))
                    using (var copiedBmp = ImageManipulator.CopyToBpp(tempBMP, 1)) {
                        string bmpFilename = String.Format("File{0}.png", indexNum);
                        copiedBmp.Save(bmpFilename, ImageFormat.Png);
                    }
                }
                catch (Exception ex) {
                    ReportFailure(ex);
                }
                finally {
                    bmp.Dispose();
                }
            });
            t.Start();
