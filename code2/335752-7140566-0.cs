    string fileName = @"c:\temp\myppt.pptx";
    using (var doc = PresentationDocument.Open(fileName, false))
    {        
      var presentation = doc.PresentationPart.Presentation;
      foreach (SlideId slide_id in presentation.SlideIdList)
      {          
        SlidePart slide_part = doc.PresentationPart.GetPartById(slide_id.RelationshipId) as SlidePart;
        if (slide_part == null || slide_part.Slide == null)
          continue;
        Slide slide = slide_part.Slide;
              
        // from a picture
        foreach (var pic in slide.Descendants<Picture>())
        {                                
          // First, get relationship id of image
          string rId = pic.BlipFill.Blip.Embed.Value;
            
          ImagePart imagePart = (ImagePart)slide.SlidePart.GetPartById(rId);
         // Get the original file name.
          Console.Out.WriteLine(imagePart.Uri.OriginalString);                        
          // Get the content type (e.g. image/jpeg).
          Console.Out.WriteLine("content-type: {0}", imagePart.ContentType);           
          // GetStream() returns the image data
          System.Drawing.Image img = System.Drawing.Image.FromStream(imagePart.GetStream());
          // You could save the image to disk using the System.Drawing.Image class
          img.Save(@"c:\temp\temp.jpg"); 
        }                    
      }
    }
