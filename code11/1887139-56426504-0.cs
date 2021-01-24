    private async Task <IronPdf.PdfDocument>RenderPdfAsync( string Html , IronPdf.PdfPrintOptions PrintOptions = null )
    {
      var Renderer = new IronPdf.HtmlToPdf();
      if(PrintOptions!=null){
        Renderer.PrintOptions = PrintOptions;
      }
      return Renderer.RenderHtmlAsPdf(Html);
    }
