            //Open the document. 
        using (PresentationDocument presentationDocument = PresentationDocument.Open("test.pptx", true))
        {
            //Just making this reference modifies the whitespace in the slide. 
            Slide slide = presentationDocument.PresentationPart.SlideParts.First().Slide;
            var sh = slide.CommonSlideData.ShapeTree.Elements<DocumentFormat.OpenXml.Presentation.Shape>().First();
            Run r = sh.TextBody.Elements<Paragraph>().First().Elements<Run>().Skip(1).FirstOrDefault();
            Console.WriteLine(">{0}<", r.Text.Text);
            //r.Text.Text = " ";
        } 
