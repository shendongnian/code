    public static SlidePart GetSlidePart(PresentationDocument presentationDocument, int slideIndex)
    {
        if (presentationDocument == null)
        {
            throw new ArgumentNullException("presentationDocument", "GetSlidePart Method: parameter presentationDocument is null");
        }
    
        // Get the number of slides in the presentation
        int slidesCount = CountSlides(presentationDocument);
    
        if (slideIndex < 0 || slideIndex >= slidesCount)
        {
            throw new ArgumentOutOfRangeException("slideIndex", "GetSlidePart Method: parameter slideIndex is out of range");
        }
    
        PresentationPart presentationPart = presentationDocument.PresentationPart;
    
        // Verify that the presentation part and presentation exist.
        if (presentationPart != null && presentationPart.Presentation != null)
        {
            Presentation presentation = presentationPart.Presentation;
    
            if (presentation.SlideIdList != null)
            {
                // Get the collection of slide IDs from the slide ID list.
                var slideIds = presentation.SlideIdList.ChildElements;
    
                if (slideIndex < slideIds.Count)
                {
                   // Get the relationship ID of the slide.
                   string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;
    
                    // Get the specified slide part from the relationship ID.
                    SlidePart slidePart = (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);
    
                     return slidePart;
                 }
             }
         }
    
         // No slide found
         return null;
    }
