            public void saveMultiInkCanvasToPdf()
            {
                string subpath = Directory.GetCurrentDirectory();          
                SaveFileDialog saveFileDialog12 = new SaveFileDialog();
                saveFileDialog12.Filter = "Pdf File|*.pdf";
                saveFileDialog12.Title = "Save Pdf File";
                saveFileDialog12.InitialDirectory = subpath;
                saveFileDialog12.ShowDialog();
                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog12.FileName == "") return;
                subpath = saveFileDialog12.FileName.Substring(0, saveFileDialog12.FileName.Length - saveFileDialog12.SafeFileName.Length);
                string extension = saveFileDialog12.FileName.Remove(subpath.IndexOf(subpath), subpath.Length);
                string[] allStr = extension.Split('.');
                if (allStr[1] == "pdf")
                {
                    using (var stream = new FileStream(saveFileDialog12.FileName, FileMode.Append, FileAccess.Write, FileShare.None))
                    {
                        iTextSharp.text.Document document = new iTextSharp.text.Document();
                        document.SetPageSize(iTextSharp.text.PageSize.A4);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream);
                        if (!document.IsOpen())
                            document.Open();
                        for (int i = 0; i < listCanvas.Count; i++)
                        {
                            RenderTargetBitmap rtb = new RenderTargetBitmap((int)listCanvas[i].Width, (int)listCanvas[i].Height, 96d, 96d, PixelFormats.Default);
                            rtb.Render(listCanvas[i]);
                            // draw the ink strokes onto the bitmap
                            DrawingVisual dvInk = new DrawingVisual();
                            DrawingContext dcInk = dvInk.RenderOpen();
                            dcInk.DrawRectangle(listCanvas[i].Background, null, new Rect(0d, 0d, listCanvas[i].Width, listCanvas[i].Height));
                            foreach (System.Windows.Ink.Stroke stroke in listCanvas[i].Strokes)
                            {
                                stroke.Draw(dcInk);
                            }
                            dcInk.Close();
                            //save bitmap to file                          
                            MemoryStream fs = new MemoryStream();
                            System.Windows.Media.Imaging.JpegBitmapEncoder encoder1 = new JpegBitmapEncoder();
                            encoder1.Frames.Add(BitmapFrame.Create(rtb));
                            encoder1.Save(fs);
                            byte[] tArr = fs.ToArray();
                            fs.Close();
                            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(tArr);
                            image.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                            image.ScaleToFit(document.PageSize.Width - 10, document.PageSize.Height - 10);//Resize image depend upon your need
                            document.Add(image);
                            document.NewPage();
                            fs.Close();
                        }
                        document.Close();
                    }
                }
            }
