    VmlDrawingPart vmlDrawingPart1 = part.GetPartById("rId8") as VmlDrawingPart;
    GenerateVmlDrawingPart1Content(vmlDrawingPart1);
    private void GenerateVmlDrawingPart1Content(VmlDrawingPart vmlDrawingPart1)
    {
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(vmlDrawingPart1.GetStream(System.IO.FileMode.OpenOrCreate), System.Text.Encoding.UTF8);
            writer.WriteRaw(vml2007);
            writer.Flush();
            writer.Close();
    }
