                foreach (Microsoft.Office.Interop.Word.Table tb in doc.Tables)
                {
                    int imageCounter = 0;
                    for (int row = 1; row <= tb.Rows.Count; row++)
                    {
                        for (int Cols = 1; Cols <= tb.Columns.Count; Cols++)
                        {
                            var tableCell = tb.Cell(row, Cols);
                            var cellText = tableCell.Range.Text;                            
                            if (cellText.Contains("Image1"))
                            {
                                tableCell.Range.Text = "";
                                if (fpnImage  != null && fpnImage.Any() && fpnImage[imageCounter].Path != null)
                                {
                                    var MediaPathImage1 = Path.Combine((HttpContext.Current.Server.MapPath(mediaImage)), fpnImage[imageCounter].Path);
                                    var rangePic = tb.Cell(row, Cols).Range;
                                    Microsoft.Office.Interop.Word.InlineShape rangePicture = rangePic.InlineShapes.AddPicture(MediaPathImage1, Type.Missing, Type.Missing, Type.Missing);
                                    rangePicture.Height = imageHeight;
                                    rangePicture.Width = imageWidth;
                                    imageCounter++;
                                }                                    
                            }
                            
                        }
                    }
                }
