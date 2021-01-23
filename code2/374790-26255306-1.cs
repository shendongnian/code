     foreach (InlineShape shape in OHeader.Range.InlineShapes) 
                                {
                                    if (shape.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                                    {
                                        shape.Delete();
                                        oSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InlineShapes.AddPicture(m_sLogoPath);
                                    }
                                }
