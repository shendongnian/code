    using (PresentationDocument doc = PresentationDocument.Open(textBox1.Text, true))
    {
           PresentationPart pp = doc.PresentationPart;
           SlidePart sp1 = pp.SlideParts.ToList<SlidePart>()[0];
           foreach (DiagramDataPart ddp in sp1.DiagramDataParts.ToList<DiagramDataPart>())
           {
                 DataModelRoot dmr = ddp.DataModelRoot;
                 List<PointList> pl = dmr.Descendants<PointList>().ToList();
                 foreach (PointList item in pl)
                 {
                        List<Point> ps = item.Descendants<Point>().ToList();
                        foreach (Point p in ps)
                        {
                              if (p.InnerText.Equals("_HELLO_"))
                              {
                                    DocumentFormat.OpenXml.Drawing.Paragraph para = p.TextBody.GetFirstChild<DocumentFormat.OpenXml.Drawing.Paragraph>();
                                    DocumentFormat.OpenXml.Drawing.Run run1 = para.GetFirstChild<DocumentFormat.OpenXml.Drawing.Run>();
                                    DocumentFormat.OpenXml.Drawing.Text text1 = run1.GetFirstChild<DocumentFormat.OpenXml.Drawing.Text>();
                                    text1.Text = "World";
                                    var textreplacement = p.InnerText;
                              }
                        }
                  }
            }
            doc.Save();
    }
