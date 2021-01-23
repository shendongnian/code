    public class MyPageEvent:IPdfPageEvent
    {
      public string variable="";
     public void OnStartPage(PdfWriter writer, Document document)
     {
           PdfContentByte cb = riter.DirectContent;;
           cb.BeginText();
           cb.SetFontAndSize(myBaseFont, 10f);
           cb.SetTextMatrix(600, 15);
           cb.ShowText(this.variable);
           cb.EndText();
     }
     ......
    }
