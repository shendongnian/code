        BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font fontRupee = new Font(bf, 8, Font.ITALIC);
        Font fontRupee1 = new Font(bf, 10, Font.BOLDITALIC);
       
        var Smallspace = FontFactory.GetFont("Calibri", 1, iTextSharp.text.Color.BLACK);
        var boldHeadFont = FontFactory.GetFont("Calibri", 13, iTextSharp.text.Color.RED);
        var boldTableFont = FontFactory.GetFont("Calibri", 11, iTextSharp.text.Color.BLACK);
        var TableFontSmall = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Color.BLACK);
       
        var TableFontmini_ARBold8Sub = FontFactory.GetFont("Arial", 11, Font.BOLD, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBoldCom = FontFactory.GetFont("Calibri", 16, Font.BOLD, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBoldComAdd = FontFactory.GetFont("Calibri", 10, Font.NORMAL, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBold82 = FontFactory.GetFont("Tahoma", 7, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBold81 = FontFactory.GetFont("Tahoma", 7, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_Ver = FontFactory.GetFont("Arial", 7, Font.ITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_VerBold = FontFactory.GetFont("Arial", 8, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBoldWef8 = FontFactory.GetFont("Calibri", 9, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBold8 = FontFactory.GetFont("Calibri", 8, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBold8Nor = FontFactory.GetFont("Arial", 8.5f, Font.ITALIC, iTextSharp.text.Color.BLACK);
        //var TableFontmini_ARBold8Nor = FontFactory.GetFont("Calibri", 7, Font.ITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBold8inc = FontFactory.GetFont("Calibri", 8.5f, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var TableFontmini_ARBoldRef = FontFactory.GetFont("Calibri", 9, Font.BOLDITALIC, iTextSharp.text.Color.BLACK);
        var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 10);
        var boldFont1 = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 8, Font.UNDERLINE);
        var boldFontm = FontFactory.GetFont(FontFactory.TIMES_BOLDITALIC, 9);
        //var boldFontm = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE);
        //var boldFontm= FontFactory.GetFont(FontFactory.TIMES_BOLD, 10, iTextSharp.text.Font.UNDERLINE);
        var TableFontmini_Ar = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Color.BLACK);
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.Color.BLACK);
        iTextSharp.text.Font timessmall = new iTextSharp.text.Font(bfTimes, 9, iTextSharp.text.Font.ITALIC, iTextSharp.text.Color.BLACK);
        var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
        var boldFonts = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
        var blackListTextFont = FontFactory.GetFont("Arial", 28, Color.BLACK);
        var redListTextFont = FontFactory.GetFont("Arial", 28, Color.RED);
       
       
        rnPL.Id = Id.SelectedValue.Trim();
        rnPL.Code = Code;
        rnPL.CodeNo = CodeNo;
        DataSet ds = rnBL.GetDetilForPDF(rnPL);
        if (ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables["tbl_Basic"];
            iTextSharp.text.Document doc = new Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
           // lblHidId.Value = dt.Rows[0]["Id"].ToString();
           
            if (dt.Rows[0]["Id"].ToString() == "4")
            {
                FilePath = Server.MapPath("images") + "\\1.jpg";
                FilePathstamplogo = Server.MapPath("images") + "\\6.png";
            }
          
           
           
            if (dt.Rows[0]["Id"].ToString() == "1")
            {
                FilePath = Server.MapPath("images") + "\\2.jpg";
                FilePathslogo = Server.MapPath("images") + "\\5.png";
            }
           
          
            
            
               
                //iTextSharp.text.Image stamplogo = iTextSharp.text.Image.GetInstance(FilePathstamplogo);
                //stamplogo.ScalePercent(75f);
                ////stamplogo.SetAbsolutePosition(doc.PageSize.Width - 36f - 140f, doc.PageSize.Height - 36f - 640f);/*ByAbhishek*/
                //stamplogo.SetAbsolutePosition(doc.PageSize.Width - 38f - 160f, doc.PageSize.Height - 38f - 700f);
                //doc.Add(stamplogo);
              
           
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(FilePath);
            jpg.ScaleAbsoluteHeight(830);
            jpg.ScaleAbsoluteWidth(600);
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            fofile = "";
            fofile = Server.MapPath("PDFComRNew");
            string crefilename;
            crefilename = Convert.ToInt32(Code.ToString()).ToString() + Convert.ToInt32(CodeNo.ToString()).ToString() + ".Pdf";
            string newPathfile = System.IO.Path.Combine(fofile, crefilename);
            PdfWriter pdfwrite = PdfWriter.GetInstance(doc, new FileStream(newPathfile, FileMode.Create));
            doc.Open();
            doc.Add(jpg);
          
            PdfPTable tableHeader = new PdfPTable(1);
            tableHeader.WidthPercentage = 50;
            PdfPCell Headspace;
            Headspace = new PdfPCell(new Phrase(" ", TableFontSmall));
            Headspace.BorderWidth = 0;
            Headspace.HorizontalAlignment = 0;/**Left=0,Centre=1,Right=2**/
            tableHeader.AddCell(Headspace);
            Headspace = new PdfPCell(new Phrase(" ", TableFontSmall));
            Headspace.BorderWidth = 0;
            Headspace.HorizontalAlignment = 0;/**Left=0,Centre=1,Right=2**/
            tableHeader.AddCell(Headspace);
            Headspace = new PdfPCell(new Phrase(" ", TableFontSmall));
            Headspace.BorderWidth = 0;
            Headspace.HorizontalAlignment = 0;/**Left=0,Centre=1,Right=2**/
            tableHeader.AddCell(Headspace);
            doc.Add(tableHeader);
            #endregion
            
            PdfPTable tblAcNo = new PdfPTable(1);
            float[] colWidthsaccingo = { 1000 };
            tblAcNo.SetWidths(colWidthsaccingo);
            PdfPCell celladdingo;
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase("  ", Smallspace));
            celladdingo.HorizontalAlignment = 1;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 2;
            tblAcNo.AddCell(celladdingo);
            celladdingo = new PdfPCell(new Phrase(" ", TableFontmini_ARBold8));
            celladdingo.HorizontalAlignment = 0;
            celladdingo.BorderWidth = 0;
            celladdingo.Colspan = 1;
            tblAcNo.AddCell(celladdingo);
            //Chunk c111 = new Chunk("Ref No : ", TableFontmini_ARBoldRef);
            //Chunk c211 = new Chunk((dt.Rows[0]["RefrenceNo"]).ToString(), TableFontmini_ARBold8Nor);
            //Phrase p211 = new Phrase();
            //p211.Add(c111);
            //p211.Add(c211);
            Paragraph pS = new Paragraph();
            //pS.Add(p211);
            /*For gst*/
            /*For space*/
            Chunk cspc = new Chunk("                                                                                                    ", TableFontmini_ARBold8);
            Phrase pcspc = new Phrase();
            pcspc.Add(cspc);
            pS.Add(pcspc);
            /*For space*/
            /*For statecode*/
            Chunk c1111 = new Chunk("Date : ", TableFontmini_ARBoldRef);
            Chunk c2111 = new Chunk((dt.Rows[0]["GenearteDate"]).ToString(), TableFontmini_ARBold8Nor);
            Phrase p2111 = new Phrase();
            p2111.Add(c1111);
            p2111.Add(c2111);
            pS.Add(p2111);
            /*For statecode*/
            /*For finally add*/
            PdfPCell cellDet_4 = new PdfPCell(pS);
            cellDet_4.HorizontalAlignment = 0; /**Left=0,Centre=1,Right=2**/
            cellDet_4.BorderWidth = 0;
            cellDet_4.Colspan = 2;
            tblAcNo.AddCell(cellDet_4);
            doc.Add(tblAcNo);
         
           
            PdfPTable tblto = new PdfPTable(1);
            float[] colWidthTo = { 1000 };
            tblto.SetWidths(colWidthTo);
            PdfPCell cellTo;
            cellTo = new PdfPCell(new Phrase("  ", Smallspace));
            cellTo.HorizontalAlignment = 1;
            cellTo.BorderWidth = 0;
            cellTo.Colspan = 2;
            tblto.AddCell(cellTo);
            cellTo = new PdfPCell(new Phrase("  ", Smallspace));
            cellTo.HorizontalAlignment = 1;
            cellTo.BorderWidth = 0;
            cellTo.Colspan = 2;
            tblto.AddCell(cellTo);
            cellTo = new PdfPCell(new Phrase("  ", Smallspace));
            cellTo.HorizontalAlignment = 1;
            cellTo.BorderWidth = 0;
            cellTo.Colspan = 2;
            tblto.AddCell(cellTo);
            cellTo = new PdfPCell(new Phrase("  ", Smallspace));
            cellTo.HorizontalAlignment = 1;
            cellTo.BorderWidth = 0;
            cellTo.Colspan = 2;
            tblto.AddCell(cellTo);
            cellTo = new PdfPCell(new Phrase("  ", Smallspace));
            cellTo.HorizontalAlignment = 1;
            cellTo.BorderWidth = 0;
            cellTo.Colspan = 2;
            tblto.AddCell(cellTo);
            cellTo = new PdfPCell(new Phrase("To, ", TableFontmini_ARBold8Nor));
            cellTo.HorizontalAlignment = 0;
            cellTo.BorderWidth = 0;
            cellTo.Colspan = 1;
            tblto.AddCell(cellTo);
            doc.Add(tblto);
            
            
            PdfPTable tblToManager = new PdfPTable(1);
            float[] colWidthToManager = { 1000 };
            tblToManager.SetWidths(colWidthToManager);
            PdfPCell cellToManager;
            cellToManager = new PdfPCell(new Phrase("  ", Smallspace));
            cellToManager.HorizontalAlignment = 1;
            cellToManager.BorderWidth = 0;
            cellToManager.Colspan = 2;
            tblToManager.AddCell(cellToManager);
            cellToManager = new PdfPCell(new Phrase(" ", TableFontmini_ARBold8Nor));
            cellToManager.HorizontalAlignment = 0;
            cellToManager.BorderWidth = 0;
            cellToManager.Colspan = 1;
            tblToManager.AddCell(cellToManager);
            doc.Add(tblToManager);
          
            PdfPTable tblBillHead = new PdfPTable(1);
            float[] colWidthBillHead = { 1000 };
            tblBillHead.SetWidths(colWidthBillHead);
            PdfPCell celltblBillHead = new PdfPCell(new Paragraph(dt.Rows[0]["Header"].ToString(), TableFontmini_ARBold8));
            celltblBillHead.HorizontalAlignment = 0;
            celltblBillHead.BorderWidth = 0;
            celltblBillHead.Colspan = 1;
            tblBillHead.AddCell(celltblBillHead);
            doc.Add(tblBillHead);
           
            PdfPTable tblSiteAdd = new PdfPTable(1);
            float[] colWidthSiteAdd = { 1000 };
            tblSiteAdd.SetWidths(colWidthSiteAdd);
            PdfPCell celltblSiteAdd = new PdfPCell(new Paragraph(dt.Rows[0]["Address"].ToString(), TableFontmini_ARBold8Nor));
            celltblSiteAdd.HorizontalAlignment = 0;
            celltblSiteAdd.BorderWidth = 0;
            celltblSiteAdd.Colspan = 1;
            tblSiteAdd.AddCell(celltblSiteAdd);
            doc.Add(tblSiteAdd);
         
            PdfPTable tblSiteCity = new PdfPTable(1);
            float[] colWidthSiteCity = { 1000 };
            tblSiteCity.SetWidths(colWidthSiteCity);
            PdfPCell celltblSiteCity = new PdfPCell(new Paragraph(dt.Rows[0]["City"].ToString(), TableFontmini_ARBold8));
            celltblSiteCity.HorizontalAlignment = 0;
            celltblSiteCity.BorderWidth = 0;
            celltblSiteCity.Colspan = 1;
            tblSiteCity.AddCell(celltblSiteCity);
            doc.Add(tblSiteCity);
            
          
            PdfPTable tblSubject = new PdfPTable(1);
            float[] colWidthSubject = { 1000 };
            tblSubject.SetWidths(colWidthSubject);
            PdfPCell cellSubject;
            cellSubject = new PdfPCell(new Phrase("  ", Smallspace));
            cellSubject.HorizontalAlignment = 1;
            cellSubject.BorderWidth = 0;
            cellSubject.Colspan = 2;
            tblSubject.AddCell(cellSubject);
            cellSubject = new PdfPCell(new Phrase("  ", Smallspace));
            cellSubject.HorizontalAlignment = 1;
            cellSubject.BorderWidth = 0;
            cellSubject.Colspan = 2;
            tblSubject.AddCell(cellSubject);
            cellSubject = new PdfPCell(new Phrase("  ", Smallspace));
            cellSubject.HorizontalAlignment = 1;
            cellSubject.BorderWidth = 0;
            cellSubject.Colspan = 2;
            tblSubject.AddCell(cellSubject);
            cellSubject = new PdfPCell(new Phrase("  ", Smallspace));
            cellSubject.HorizontalAlignment = 1;
            cellSubject.BorderWidth = 0;
            cellSubject.Colspan = 2;
            tblSubject.AddCell(cellSubject);
            cellSubject = new PdfPCell(new Phrase("   Sub.: Application For leave", TableFontmini_ARBold8Sub));
            cellSubject.HorizontalAlignment = 1;/**Left=0,Centre=1,Right=2**/
            cellSubject.BorderWidth = 0;
            cellSubject.Colspan = 1;
            tblSubject.AddCell(cellSubject);
            doc.Add(tblSubject);
           
            
            PdfPTable tblDEarSir = new PdfPTable(1);
            float[] colWidthDEarSir = { 1000 };
            tblDEarSir.SetWidths(colWidthDEarSir);
            PdfPCell cellDEarSir;
            cellDEarSir = new PdfPCell(new Phrase("  ", Smallspace));
            cellDEarSir.HorizontalAlignment = 1;
            cellDEarSir.BorderWidth = 0;
            cellDEarSir.Colspan = 2;
            tblDEarSir.AddCell(cellDEarSir);
            cellDEarSir = new PdfPCell(new Phrase("  ", Smallspace));
            cellDEarSir.HorizontalAlignment = 1;
            cellDEarSir.BorderWidth = 0;
            cellDEarSir.Colspan = 2;
            tblDEarSir.AddCell(cellDEarSir);
            cellDEarSir = new PdfPCell(new Phrase("  ", Smallspace));
            cellDEarSir.HorizontalAlignment = 1;
            cellDEarSir.BorderWidth = 0;
            cellDEarSir.Colspan = 2;
            tblDEarSir.AddCell(cellDEarSir);
            cellDEarSir = new PdfPCell(new Phrase("Dear Sir, ", TableFontmini_ARBold8));
            cellDEarSir.HorizontalAlignment = 0;
            cellDEarSir.BorderWidth = 0;
            cellDEarSir.Colspan = 1;
            tblDEarSir.AddCell(cellDEarSir);
            doc.Add(tblDEarSir);
            
            PdfPTable tblPara1 = new PdfPTable(1);
            float[] colWidthPara1 = { 1200 };
            tblPara1.SetWidths(colWidthPara1);
            PdfPCell cellPara1;
            cellPara1 = new PdfPCell(new Phrase("  ", Smallspace));
            cellPara1.HorizontalAlignment = 1;
            cellPara1.BorderWidth = 0;
            cellPara1.Colspan = 4;
            tblPara1.AddCell(cellPara1);
            cellPara1 = new PdfPCell(new Phrase("  ", Smallspace));
            cellPara1.HorizontalAlignment = 1;
            cellPara1.BorderWidth = 0;
            cellPara1.Colspan = 4;
            tblPara1.AddCell(cellPara1);
            cellPara1 = new PdfPCell(new Phrase("  ", Smallspace));
            cellPara1.HorizontalAlignment = 1;
            cellPara1.BorderWidth = 0;
            cellPara1.Colspan = 4;
            tblPara1.AddCell(cellPara1);
            cellPara1 = new PdfPCell(new Paragraph("i beg to say that i m feelling unwell", TableFontmini_ARBold8Nor));
            cellPara1.HorizontalAlignment = 3;
            cellPara1.BorderWidth = 0;
            cellPara1.Colspan = 1;
            tblPara1.AddCell(cellPara1);
            doc.Add(tblPara1);
          
            PdfPTable tblPara2 = new PdfPTable(1);
            float[] colWidthPara2 = { 1400 };
            tblPara2.SetWidths(colWidthPara2);
            PdfPCell cellPara2;
            cellPara2 = new PdfPCell(new Phrase("  ", Smallspace));
            cellPara2.HorizontalAlignment = 1;
            cellPara2.BorderWidth = 0;
            cellPara2.Colspan = 4;
            tblPara2.AddCell(cellPara2);
            cellPara2 = new PdfPCell(new Phrase("  ", Smallspace));
            cellPara2.HorizontalAlignment = 1;
            cellPara2.BorderWidth = 0;
            cellPara2.Colspan = 4;
            tblPara2.AddCell(cellPara2);
            cellPara2 = new PdfPCell(new Paragraph("Kindly give me leave for four days ", TableFontmini_ARBold8Nor));
            cellPara2.HorizontalAlignment = 3;
            cellPara2.BorderWidth = 0;
            cellPara2.Colspan = 1;
            tblPara2.AddCell(cellPara2);
            doc.Add(tblPara2);
            
            PdfPTable tblPara3 = new PdfPTable(1);
            float[] colWidthPara3 = { 1200 };
            tblPara3.SetWidths(colWidthPara3);
            PdfPCell cellPara3;
            cellPara3 = new PdfPCell(new Phrase("  ", Smallspace));
            cellPara3.HorizontalAlignment = 1;
            cellPara3.BorderWidth = 0;
            cellPara3.Colspan = 4;
            tblPara3.AddCell(cellPara3);
            cellPara3 = new PdfPCell(new Paragraph(" from Date" + dt.Rows[0]["Date"].ToString(), TableFontmini_ARBold8Nor));
            cellPara3.HorizontalAlignment = 3;
            cellPara3.BorderWidth = 0;
            cellPara3.Colspan = 1;
            tblPara3.AddCell(cellPara3);
            doc.Add(tblPara3);
            
            PdfPTable tblLastPara = new PdfPTable(1);
            float[] colWidthLastPara = { 1200 };
            tblPara1.SetWidths(colWidthLastPara);
            PdfPCell cellLastPara;
            cellLastPara = new PdfPCell(new Phrase("  ", Smallspace));
            cellLastPara.HorizontalAlignment = 1;
            cellLastPara.BorderWidth = 0;
            cellLastPara.Colspan = 2;
            tblLastPara.AddCell(cellLastPara);
            cellLastPara = new PdfPCell(new Phrase("  ", Smallspace));
            cellLastPara.HorizontalAlignment = 1;
            cellLastPara.BorderWidth = 0;
            cellLastPara.Colspan = 2;
            tblLastPara.AddCell(cellLastPara);
            cellLastPara = new PdfPCell(new Phrase("  ", Smallspace));
            cellLastPara.HorizontalAlignment = 1;
            cellLastPara.BorderWidth = 0;
            cellLastPara.Colspan = 2;
            tblLastPara.AddCell(cellLastPara);
            cellLastPara = new PdfPCell(new Paragraph("Thank you so much for giving me leave", TableFontmini_ARBold8Nor));
            cellLastPara.HorizontalAlignment = 3;
            cellLastPara.BorderWidth = 0;
            cellLastPara.Colspan = 1;
            tblLastPara.AddCell(cellLastPara);
            doc.Add(tblLastPara);
           
            PdfPTable tblThankingYou = new PdfPTable(1);
            float[] colWidthThankingYou = { 1000 };
            tblSiteCity.SetWidths(colWidthSiteCity);
            PdfPCell celltblThankingYou;
            celltblThankingYou = new PdfPCell(new Phrase("  ", Smallspace));
            celltblThankingYou.HorizontalAlignment = 1;
            celltblThankingYou.BorderWidth = 0;
            celltblThankingYou.Colspan = 2;
            tblThankingYou.AddCell(celltblThankingYou);
            celltblThankingYou = new PdfPCell(new Phrase("  ", Smallspace));
            celltblThankingYou.HorizontalAlignment = 1;
            celltblThankingYou.BorderWidth = 0;
            celltblThankingYou.Colspan = 2;
            tblThankingYou.AddCell(celltblThankingYou);
            celltblThankingYou = new PdfPCell(new Phrase("  ", Smallspace));
            celltblThankingYou.HorizontalAlignment = 1;
            celltblThankingYou.BorderWidth = 0;
            celltblThankingYou.Colspan = 2;
            tblThankingYou.AddCell(celltblThankingYou);
            celltblThankingYou = new PdfPCell(new Paragraph("Thanking You,", TableFontmini_ARBold8Nor));
            celltblThankingYou.HorizontalAlignment = 0;
            celltblThankingYou.BorderWidth = 0;
            celltblThankingYou.Colspan = 1;
            tblThankingYou.AddCell(celltblThankingYou);
            doc.Add(tblThankingYou);
          
            PdfPTable tblYorsSinc = new PdfPTable(1);
            float[] colWidthYorsSinc = { 1000 };
            tblYorsSinc.SetWidths(colWidthYorsSinc);
            PdfPCell cellYorsSinc;
            cellYorsSinc = new PdfPCell(new Phrase("  ", Smallspace));
            cellYorsSinc.HorizontalAlignment = 1;
            cellYorsSinc.BorderWidth = 0;
            cellYorsSinc.Colspan = 2;
            tblYorsSinc.AddCell(cellYorsSinc);
            cellYorsSinc = new PdfPCell(new Paragraph("Sincerely Yours,", TableFontmini_ARBold8Nor));
            cellYorsSinc.HorizontalAlignment = 0;
            cellYorsSinc.BorderWidth = 0;
            cellYorsSinc.Colspan = 1;
            tblYorsSinc.AddCell(cellYorsSinc);
            doc.Add(tblYorsSinc);
           
            PdfPTable tblAuthSignat = new PdfPTable(1);
            float[] colWidthAuthSignat = { 1000 };
            tblAuthSignat.SetWidths(colWidthAuthSignat);
            PdfPCell cellAuthSignat;
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            cellAuthSignat = new PdfPCell(new Phrase("  ", Smallspace));
            cellAuthSignat.HorizontalAlignment = 1;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 2;
            tblAuthSignat.AddCell(cellAuthSignat);
            tblAuthSignat.AddCell(cellAuthSignat);
            cellAuthSignat = new PdfPCell(new Paragraph("(Student Signatature)", TableFontmini_ARBold8));
            cellAuthSignat.HorizontalAlignment = 0;
            cellAuthSignat.BorderWidth = 0;
            cellAuthSignat.Colspan = 1;
            tblAuthSignat.AddCell(cellAuthSignat);
            doc.Add(tblAuthSignat);
           
            PdfPTable tblForCom = new PdfPTable(1);
            float[] colWidthForCom = { 1000 };
            tblYorsSinc.SetWidths(colWidthForCom);
            PdfPCell cellForCom;
            cellForCom = new PdfPCell(new Phrase("  ", Smallspace));
            cellForCom.HorizontalAlignment = 1;
            cellForCom.BorderWidth = 0;
            cellForCom.Colspan = 2;
            tblForCom.AddCell(cellForCom);
            cellForCom = new PdfPCell(new Paragraph("For  " + dt.Rows[0]["Name"].ToString(), TableFontmini_ARBold8));
            cellForCom.HorizontalAlignment = 0;
            cellForCom.BorderWidth = 0;
            cellForCom.Colspan = 1;
            tblForCom.AddCell(cellForCom);
            doc.Add(tblForCom);
           
            
              
                pdfwrite.PageEvent = new FooterRN(dt.Rows[0]["Address"].ToString(), Convert.ToInt32(Code.ToString()).ToString(), dt.Rows[0]["Id"].ToString(), dt.Rows[0]["Studentmail"].ToString(), dt.Rows[0]["PhoneNo1"].ToString(), dt.Rows[0]["StudentName"].ToString());
               
           
            doc.Close();
        }
       
  
