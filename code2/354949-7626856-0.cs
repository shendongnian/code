    using (var doc = PresentationDocument.Open(fileName, false))
    {
      var presentation = doc.PresentationPart.Presentation;
      foreach (SlideId slide_id in presentation.SlideIdList)
      {
        SlidePart slide_part = doc.PresentationPart.GetPartById(slide_id.RelationshipId) as SlidePart;
        if (slide_part == null || slide_part.Slide == null)
            continue;
        Slide slide = slide_part.Slide;
                    
        foreach (var pic in slide.Descendants<DocumentFormat.OpenXml.Presentation.Picture>())
        {
          string id = pic.NonVisualPictureProperties.NonVisualDrawingProperties.Id;
          string desc = pic.NonVisualPictureProperties.NonVisualDrawingProperties.Description;
          Console.Out.WriteLine(desc);
        }
      }
    }
