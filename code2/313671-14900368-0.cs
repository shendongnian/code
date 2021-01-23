    public void SaveDocumentPagesToImages(IDocumentPaginatorSource document, string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath)) return;
            if (dirPath[dirPath.Length - 1] != '\\')
                dirPath += "\\";
            if (!Directory.Exists(dirPath)) return;
            MemoryStream[] streams = null;
            try
            {
                int pageCount = document.DocumentPaginator.PageCount;
                DocumentPage[] pages = new DocumentPage[pageCount];
                for (int i = 0; i < pageCount; i++)
                    pages[i] = document.DocumentPaginator.GetPage(i);
                streams = new MemoryStream[pages.Count()];
                for (int i = 0; i < pages.Count(); i++)
                {
                    DocumentPage source = pages[i];
                    streams[i] = new MemoryStream();
                    RenderTargetBitmap renderTarget =
                       new RenderTargetBitmap((int)source.Size.Width,
                                               (int)source.Size.Height,
                                               96, // WPF (Avalon) units are 96dpi based
                                               96,
                                               System.Windows.Media.PixelFormats.Default);
                    renderTarget.Render(source.Visual);
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();  // Choose type here ie: JpegBitmapEncoder, etc
                    encoder.QualityLevel = 100;
                    encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                    encoder.Save(streams[i]);
                    FileStream file = new FileStream(dirPath + "Page_" + (i+1) + ".jpg", FileMode.CreateNew);
                    file.Write(streams[i].GetBuffer(), 0, (int)streams[i].Length);
                    file.Close();
                    streams[i].Position = 0;
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
            finally
            {
                if (streams != null)
                {
                    foreach (MemoryStream stream in streams)
                    {
                        stream.Close();
                        stream.Dispose();
                    }
                }
            }
        }
