    public class ImageExtractor : IRenderListener
    {
	    private string caption;
	    private bool _captionFound;
	    private string _outputFolder;
	    ....
	    ....
        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderText(TextRenderInfo renderInfo) {
            // If this line of text contains the caption, set _captionFound to true
        	if (renderInfo.GetText().Contains(_caption))
        		_captionFound = true;
        }
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            // Skip the image if _captionFound is false
         	if (!_captionFound)
        		return;
            // _captionFound is true, so extract the image
		    // Code to extract image
            // Set _captionFound back to false, so that only the first image found is
            // extracted.
            _captionFound = false;
  
        }
        public static int ExtractImageByCaption(string caption, string pdfPath, string outputFolder, string outputFolder, bool overwriteExistingFiles, string[] fileTypes = null)
	    {
            var instance = new ImageExtractor(outputFilePrefix, outputFolder, overwriteExistingFiles, fileTypes, 0);
            instance._caption = caption;
	        instance._outputFolder = outputFolder;
            using (var pdfReader = new PdfReader(pdfPath))
            {
                if (pdfReader.IsEncrypted())
                    throw new ApplicationException(pdfPath + " is encrypted.");
                var pdfParser = new PdfReaderContentParser(pdfReader);
                while (instance._currentPage <= pdfReader.NumberOfPages)
                {
                    pdfParser.ProcessContent(instance._currentPage, instance);
                    instance._currentPage++;
                }
            }
	    }
    }
