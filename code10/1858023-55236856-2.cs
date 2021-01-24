    internal class ImageWithTitleRenderListener : IRenderListener
    {
        int imageNumber = 0;
        String format;
        bool expectingTitle = false;
        public ImageWithTitleRenderListener(String format)
        {
            this.format = format;
        }
        public void BeginTextBlock()
        { }
        public void EndTextBlock()
        { }
        public void RenderText(TextRenderInfo renderInfo)
        {
            if (expectingTitle)
            {
                expectingTitle = false;
                File.WriteAllText(string.Format(format, imageNumber, "txt"), renderInfo.GetText());
            }
        }
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            imageNumber++;
            expectingTitle = true;
            PdfImageObject imageObject = renderInfo.GetImage();
            
            if (imageObject == null)
            {
                Console.WriteLine("Image {0} could not be read.", imageNumber);
            }
            else
            {
                File.WriteAllBytes(string.Format(format, imageNumber, imageObject.GetFileType()), imageObject.GetImageAsBytes());
            }
        }
    }
