    public class SimpleMixedExtractionStrategy : LocationTextExtractionStrategy
    {
        FieldInfo field = typeof(LocationTextExtractionStrategy).GetField("locationalResult", BindingFlags.Instance | BindingFlags.NonPublic);
        LineSegment UNIT_LINE = new LineSegment(new Vector(0, 0, 1), new Vector(1, 0, 1));
        String outputPath;
        String name;
        int counter = 0;
        public SimpleMixedExtractionStrategy(String outputPath, String name)
        {
            this.outputPath = outputPath;
            this.name = name;
        }
        public override void RenderImage(ImageRenderInfo renderInfo)
        {
            PdfImageObject image = renderInfo.GetImage();
            if (image == null) return;
            int number = counter++;
            String filename = name + "-" + number + "." + image.GetFileType();
            File.WriteAllBytes(outputPath + filename, image.GetImageAsBytes());
            LineSegment segment = UNIT_LINE.TransformBy(renderInfo.GetImageCTM());
            TextChunk location = new TextChunk("[" + filename + "]", segment.GetStartPoint(), segment.GetEndPoint(), 0f);
            List<TextChunk> locationalResult = (List<TextChunk>)field.GetValue(this);
            locationalResult.Add(location);
        }
    }
