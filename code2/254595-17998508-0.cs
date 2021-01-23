    StringBuilder chistHeader = new StringBuilder();
    StringBuilder chistCourses = new StringBuilder();
    HttpContext.Current.Response.ContentType = "application/pdf";
    HttpContext.Current.Response.AddHeader("content-disposition", "inline;filename=CourseHistory.pdf");
    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Document pdfDoc = new Document();
    PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
    pdfDoc.Open();
    chistHeader = CourseHistoryHeader(Convert.ToInt32(hdUserID.Value), hdSystemPath.Value, "CourseHistory");
    chistCourses = CourseHistoryCourses(Convert.ToInt32(hdUserID.Value), hdSystemPath.Value, "CourseHistory");
            
                      
          
            //write header for the pdf
    foreach (IElement element in HTMLWorker.ParseToList(new StringReader(chistHeader.ToString()), new StyleSheet()))
        {
            pdfDoc.Add(element);
        }
    //have to manually draw a line this way as ItextSharp doesn't allow a <hr> tag....
    iTextSharp.text.pdf.draw.LineSeparator line1 = new    iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
    pdfDoc.Add(new Chunk(line1));
     //write out the list of courses
     foreach (IElement element in HTMLWorker.ParseToList(new StringReader(chistCourses.ToString()), new StyleSheet()))
        {
            pdfDoc.Add(element);
        }
     pdfDoc.Close();
     HttpContext.Current.Response.Write(pdfDoc);
     HttpContext.Current.Response.End();
