     private static Footer BuildFooter(FooterPart hp, string title)
            {                   
                ImagePart ip = hp.AddImagePart(ImagePartType.Jpeg);
                string imageRelationshipID = hp.GetIdOfPart(ip);
                
                using (Stream imgStream = ip.GetStream())
                {
                    System.Drawing.Bitmap logo = DocumentResources._default;
                    logo.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
    
                Footer h = new Footer();
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                Run r = new Run();
                Drawing drawing = BuildImage(imageRelationshipID, "_default.jpg", 200, 30);
                r.Append(drawing);
                p.Append(r);
                r = new Run();
                RunProperties rPr = new RunProperties();
                TabChar tab = new TabChar();            
                Bold b = new Bold();
                Color color = new Color { Val = "000000" };
                DocumentFormat.OpenXml.Wordprocessing.FontSize sz = new DocumentFormat.OpenXml.Wordprocessing.FontSize {Val = Convert.ToString("40")};
                Text t = new Text { Text = title };
                rPr.Append(b);
                rPr.Append(color);
                rPr.Append(sz);
                r.Append(rPr);
                r.Append(tab);
                r.Append(t);
                p.Append(r);
                h.Append(p);
                return h;
            }
