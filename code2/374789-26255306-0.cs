     foreach(Microsoft.Office.Interop.Word.Shape Headershape in OHeader.Shapes)
                            {
                               InlineShape inlineshape = Headershape.ConvertToInlineShape();
                               Range PictureRange = inlineshape.Range;
                               inlineshape.Delete();
                               PictureRange.InlineShapes.AddPicture(m_sLogoPath);
                            }
