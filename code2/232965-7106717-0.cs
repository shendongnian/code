    /// <summary>
    /// Get all content controls contained in the document.
    /// </summary>
    /// <param name="wordDocument"></param>
    /// <returns></returns>
    public static List<ContentControl> GetAllContentControls(Document wordDocument)
    {
        if (null == wordDocument)
            throw new ArgumentNullException("wordDocument");
        List<ContentControl> ccList = new List<ContentControl>();
        // The code below search content controls in all
        // word document stories see http://word.mvps.org/faqs/customization/ReplaceAnywhere.htm
        Range rangeStory;
        foreach (Range range in wordDocument.StoryRanges)
        {
            rangeStory = range;
            do
            {
                try
                {
                    foreach (ContentControl cc in range.ContentControls)
                    {
                        returnValue.Add(cc);
                    }
                    // Get the content controls in the shapes ranges
                    foreach (Shape shape in range.ShapeRange)
                    {
                        foreach (ContentControl cc in shape.TextFrame.TextRange.ContentControls)
                        {
                            returnValue.Add(cc);
                        }
                    }
                }
                catch (COMException) { }
                rangeStory = rangeStory.NextStoryRange;
            }
            while (rangeStory != null);
        }
        return ccList;
    }
