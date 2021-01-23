                        //Loop through each image
                        for (int i = 0; i < AllImages.Length; i++)
                        {
                            //Add a new page to the PDF
                            document.NewPage();
                            //Create our image instance
                            pageImage = iTextSharp.text.Image.GetInstance(AllImages[i]);
                            //If we only have one image or we are on the second to last one
                            if ((AllImages.Length == 1) | (i == (AllImages.Length - 1)))
                            {
                                //Scale based on the height of document minus the table height
                                pageImage.ScaleToFit(document.PageSize.Width, document.PageSize.Height - tableHeight);
                            }
                            else
                            {
                                //Scale normally
                                pageImage.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                            }
                            
                            pageImage.Alignment = iTextSharp.text.Image.ALIGN_TOP | iTextSharp.text.Image.ALIGN_CENTER;
                            document.Add(pageImage);
                            //If we only have one image or we are on the second to last one
                            if ((AllImages.Length == 1) | (i == (AllImages.Length - 1)))
                            {
                                //Draw the table to the bottom left corner of the document
                                t.WriteSelectedRows(0, t.Rows.Count, 0, tableHeight, writer.DirectContent);
                            }
                        }
