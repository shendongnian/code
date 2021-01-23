        private IList<byte[]> GetTifPagesFromXps(string xXpsFileName, double xQuality)
        {
            using (var xpsDoc = new XpsDocument(xXpsFileName, FileAccess.Read))
            {
                var docSeq = xpsDoc.GetFixedDocumentSequence();
                var tifPages = new List<byte[]>();
                for (var i = 0; i < docSeq.DocumentPaginator.PageCount; i++)
                {
                    using (var docPage = docSeq.DocumentPaginator.GetPage(i))
                    {
                        var renderTarget = new RenderTargetBitmap((int)(docPage.Size.Width * xQuality), (int)(docPage.Size.Height * xQuality), 96 * xQuality, 96 * xQuality, PixelFormats.Default);
                        renderTarget.Render(docPage.Visual);
                        var jpegEncoder = new JpegBitmapEncoder { QualityLevel = 100 };
                        jpegEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
                        byte[] buffer;
                        using (var memoryStream = new MemoryStream())
                        {
                            jpegEncoder.Save(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            buffer = memoryStream.GetBuffer();
                        }
                        tifPages.Add(buffer);
                    }
                }
                xpsDoc.Close();
                return tifPages.ToArray();
            }
        }
