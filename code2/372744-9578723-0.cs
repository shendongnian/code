        public static void Do()
        {
            string filename = @"c:\temp\m.docx";
            byte[] reportData = GetWordReport();
           // File.WriteAllBytes(filename, reportData);
            //MessageBox.Show("File " + filename + " created");
        }
        private static byte[] GetWordReport()
        {
           // using (MemoryStream stream = new MemoryStream())
           // {
                //var template = GetTemplateData();
                //stream.Write(template, 0, template.Length);
                using (WordprocessingDocument docx = WordprocessingDocument.Open(@"c:\temp\m.docx", true))
                {
                    // Some changes on docx
                    docx.MainDocumentPart.Document = GenerateMainDocumentPart(6,4);
                    var imagePart = docx.MainDocumentPart.AddNewPart<ImagePart>("image/jpeg", "rIdImagePart1");
                    GenerateImagePart(imagePart);
                }
              //  stream.Seek(0, SeekOrigin.Begin);
               // return stream.ToArray();
           // }
            return null;
        }
        private static byte[] GetTemplateData()
        {
            using (MemoryStream targetStream = new MemoryStream())
            using (BinaryReader sourceReader = new BinaryReader(File.Open(@"c:\temp\m_2.docx", FileMode.Open)))
            {
                byte[] buffer = new byte[4096];
                int num = 0;
                do
                {
                    num = sourceReader.Read(buffer, 0, 4096);
                    if (num > 0)
                        targetStream.Write(buffer, 0, num);
                }
                while (num > 0);
                targetStream.Seek(0, SeekOrigin.Begin);
                return targetStream.ToArray();
            }
        }
        private static void GenerateImagePart(OpenXmlPart part)
        {
            using (Stream imageStream = File.Open(@"c:\temp\image002.jpg", FileMode.Open))
            {
                part.FeedData(imageStream);
            }
        }
        private static Document GenerateMainDocumentPart(int cx,int cy)
        {
            long LCX = cx*261257L;
            long LCY = cy*261257L;
            var element =
                new Document(
                    new Body(
                        new Paragraph(
                            new Run(
                                new RunProperties(
                                    new NoProof()),
                                new Drawing(
                                    new wp.Inline(
                                        new wp.Extent() { Cx = LCX, Cy = LCY },
                                        new wp.EffectExtent() { LeftEdge = 0L, TopEdge = 19050L, RightEdge = 0L, BottomEdge = 0L },
                                        new wp.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 0", Description = "Forest Flowers.jpg" },
                                        new wp.NonVisualGraphicFrameDrawingProperties(
                                            new a.GraphicFrameLocks() { NoChangeAspect = true }),
                                        new a.Graphic(
                                            new a.GraphicData(
                                                new pic.Picture(
                                                    new pic.NonVisualPictureProperties(
                                                        new pic.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "Forest Flowers.jpg" },
                                                        new pic.NonVisualPictureDrawingProperties()),
                                                    new pic.BlipFill(
                                                        new a.Blip() { Embed = "rIdImagePart1", CompressionState = a.BlipCompressionValues.Print },
                                                        new a.Stretch(
                                                            new a.FillRectangle())),
                                                    new pic.ShapeProperties(
                                                        new a.Transform2D(
                                                            new a.Offset() { X = 0L, Y = 0L },
                                                            new a.Extents() { Cx = LCX, Cy = LCY }),
                                                        new a.PresetGeometry(
                                                            new a.AdjustValueList()
                                                        ) { Preset = a.ShapeTypeValues.Rectangle }))
                                            ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                    ) { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U }))
                        ) { RsidParagraphAddition = "00A2180E", RsidRunAdditionDefault = "00EC4DA7" },
                        new SectionProperties(
                            new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U },
                            new PageMargin() { Top = 1440, Right = (UInt32Value)1800U, Bottom = 1440, Left = (UInt32Value)1800U, Header = (UInt32Value)851U, Footer = (UInt32Value)992U, Gutter = (UInt32Value)0U },
                            new Columns() { Space = ((UInt32Value)425U).ToString() },
                            new DocGrid() { Type = DocGridValues.Lines, LinePitch = 312 }
                        ) { RsidR = "00A2180E", RsidSect = "00A2180E" }));
            return element;
        }
