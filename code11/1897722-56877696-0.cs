            public static void chkBoxesCreator()
            {  
               String[] texts = { "one", "two", "three" };
               
                using (var pdfDoc = new Document(PageSize.A4))
                using (var output = new FileStream(fileLoc, FileMode.Create))
                    using (var writer = PdfWriter.GetInstance(pdfDoc, output))
             
                {
                  
                    {
                        pdfDoc.Open();                     
    
                        PdfContentByte cb = writer.DirectContent;
                        Rectangle _rect;
                        PdfFormField _Field1;
    
                        PdfAppearance[] checkBoxes = new PdfAppearance[2];
                        //set first  checkBox style
                        checkBoxes[0] = cb.CreateAppearance(20, 20);
                        checkBoxes[0].Rectangle(1, 1, 18, 18);
                        checkBoxes[0].Stroke();
    
                        //set second  checkBox style
                        checkBoxes[1] = cb.CreateAppearance(20, 20);                  
                        checkBoxes[1].Rectangle(1, 1, 18, 18);
                        checkBoxes[1].FillStroke();
                   
                        RadioCheckField _checkbox1;
    
                        for (int i = 0; i < texts.Length; i++)
                        {
                            _rect = new Rectangle(180, 806 - i * 40, 200, 788 - i * 40); //can be any location
                            _checkbox1 = new RadioCheckField(writer, _rect, texts[i], "on");
                            _Field1 = _checkbox1.CheckField;
                            _Field1.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "Off", checkBoxes[0]);
                            _Field1.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "On", checkBoxes[1]);
                            writer.AddAnnotation(_Field1);
    
                            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(texts[i], new Font(Font.FontFamily.HELVETICA, 18)), 210, 790 - i * 40, 0);
                        }
    
                        cb = writer.DirectContent;
                        pdfDoc.Close();
                    }
                }
            }
