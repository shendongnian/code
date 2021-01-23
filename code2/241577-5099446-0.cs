        static void Main(string[] args)
        {
            PdfReader reader = new PdfReader(@"c:\test.pdf");
            StringBuilder builder = new StringBuilder();
            for (int x = 1; x <= reader.NumberOfPages; x++)
            {
                PdfDictionary page = reader.GetPageN(x);
                IRenderListener listener = new SBTextRenderer(builder);
                PdfContentStreamProcessor processor = new PdfContentStreamProcessor(listener);
                PdfDictionary pageDic = reader.GetPageN(x);
                PdfDictionary resourcesDic = pageDic.GetAsDict(PdfName.RESOURCES);
                processor.ProcessContent(ContentByteUtils.GetContentBytesForPage(reader, x), resourcesDic);
            }
        }
    public class SBTextRenderer : IRenderListener
    {
        private StringBuilder _builder;
        public SBTextRenderer(StringBuilder builder)
        {
            _builder = builder;
        }
        #region IRenderListener Members
        public void BeginTextBlock()
        {
        }
        public void EndTextBlock()
        {
        }
        public void RenderImage(ImageRenderInfo renderInfo)
        {
        }
        public void RenderText(TextRenderInfo renderInfo)
        {
            _builder.Append(renderInfo.GetText());
        }
        #endregion
    }
