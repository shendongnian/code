            using (WordprocessingDocument doc = WordprocessingDocument.Open(SourceDoc, false))
            {
               
                //List<ChartPart> chartFind = doc.MainDocumentPart.ChartParts.ToList();
                //List<Drawing> drawingList = doc.MainDocumentPart.Document.Descendants<Drawing>().ToList();
                MainDocumentPart mainPartDoc = doc.MainDocumentPart;
                var mainDoc = mainPartDoc.Document;
                using (WordprocessingDocument copydoc = WordprocessingDocument.Open(stream, true))
                {
                    MainDocumentPart mainPart = copydoc.MainDocumentPart;
                    var document = mainPart.Document;
                    var bmStart = document.Descendants<BookmarkStart>();
                    var bmEnd = document.Descendants<BookmarkEnd>();
                    foreach (BookmarkStart bookMarkStart in bmStart)
                    {
                        if (bookMarkStart.Name == "test")
                        {
                            //find charts and names from original document
                            List<ChartPart> findCharts = mainPartDoc.ChartParts.ToList();
                            var partCheck = (from f in findCharts
                                             select f.ChartSpace.GetFirstChild<Chart>().Title.InnerText).ToList();
                            ChartPart chartPart = mainPart.AddNewPart<ChartPart>();
                            ChartPart chartSelect = findCharts[3];
                            //ChartPart chartSelect = mainPartDoc.ChartParts.FirstOrDefault();
                            chartPart.ChartSpace = (ChartSpace)chartSelect.ChartSpace.Clone();
                          
                            string relId = mainPart.GetIdOfPart(chartPart);
                           
                            AutoUpdate autoUpdate1 = new AutoUpdate() { Val = false };
                            chartPart.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject", 
                                new System.Uri("NULL", System.UriKind.Relative), "rId2");
                            Paragraph paragraph = new Paragraph();
                            Drawing drawing = new Drawing();
                            Run run = new Run();
                            Inline inline = new Inline() { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U, AnchorId = "716A168E", EditId = "2D11B07F" };
                            Extent extent = new Extent() { Cx = 6572250L, Cy = 2586038L };
                            EffectExtent effectExtent1 = new EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 5080L };
                            DocProperties docProperties1 = new DocProperties() { Id = (UInt32Value)13U, Name = "Chart 13" };
                            NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new NonVisualGraphicFrameDrawingProperties();
                            dr.Graphic graphic = new dr.Graphic();
                            graphic.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
                            dr.GraphicData graphicData = new dr.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" };
                            ChartReference chartReference1 = new ChartReference() { Id = relId };
                            chartReference1.AddNamespaceDeclaration("c", "http://schemas.openxmlformats.org/drawingml/2006/chart");
                            chartReference1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
                            graphicData.Append(chartReference1);
                            graphic.Append(graphicData);
                            inline.Append(extent);
                            inline.Append(effectExtent1);
                            inline.Append(docProperties1);
                            inline.Append(nonVisualGraphicFrameDrawingProperties1);
                            inline.Append(graphic);
                            drawing.Append(inline);
                            run.Append(drawing);
                            paragraph.Append(run);
                            var id = bookMarkStart.Id.Value;
                            var bookmarkEnd = bmEnd.Where(i => i.Id.Value == id).First();
                            bookmarkEnd.Parent.InsertAfterSelf(paragraph);
                            // mainPart.Document.Body.Append(paragraph);
                        }
                    }
                }
  
