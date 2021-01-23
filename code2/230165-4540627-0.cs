    myWriter.setPageEvent(new BackgroundPageEvent(backgroundImage));
    class BackgroundPageEvent extends PdfPageEventHelper {
      Image backgroundImage = null;
      public BackgroundPageEvent( Image img ) {
        backgroundImage = img;
      }
      public void onStartPage(PdfWriter writer, Document doc) {
        PdfContentByte underContent = writer.getDirectContentUnder();
        underContent.addImage(backgroundImage);
      }
    }
