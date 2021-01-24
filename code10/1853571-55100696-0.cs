     ColumnText ct = new ColumnText(contentByte);
     ct.SetSimpleColumn(rec);
     ct.AddElement(new iTextSharp.text.Paragraph(tb.Text.ToString()));
     int status = ct.Go(true);
     Boolean fits = !ColumnText.HasMoreText(status);
     if (fits)
     {
           ColumnText ctxt = new ColumnText(contentByte);
           ctxt.SetSimpleColumn(rec);
           ctxt.AddElement(new iTextSharp.text.Paragraph(tb.Text.ToString()));
           ctxt.Go();
      }else
      {
           double fontsize = tb.FontSize - 2;
           while(!fits && fontsize > 1)
           {
                fontsize -= 0.1;
                iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph(tb.Text);
                p.Font = new iTextSharp.text.Font(BaseFont.CreateFont());
                p.Font.Size = (float)fontsize;
                ColumnText ctxt = new ColumnText(contentByte);
                ctxt.SetSimpleColumn(rec);
                ctxt.AddElement(p);
                int stat = ctxt.Go(true);
                fits = !ColumnText.HasMoreText(stat);
           }
           iTextSharp.text.Paragraph par = new iTextSharp.text.Paragraph(tb.Text);
           par.Font = new iTextSharp.text.Font(BaseFont.CreateFont());
           par.Font.Size = (float)fontsize;
           ColumnText coltxt = new ColumnText(contentByte);
           coltxt.SetSimpleColumn(rec);
           coltxt.AddElement(par);
           coltxt.Go();
      }
 
