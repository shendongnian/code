    public class OffsetColorizer : DocumentColorizingTransformer
    {
    	public int StartOffset { get; set; }
    	public int EndOffset { get; set; }
    
    	protected override void ColorizeLine(DocumentLine line)
    	{
    		if (line.Length == 0)
    			return;
    
    		if (line.Offset < StartOffset || line.Offset > EndOffset)
    			return;
    
    		int start = line.Offset > StartOffset ? line.Offset : StartOffset;
    		int end = EndOffset > line.EndOffset ? line.EndOffset : EndOffset;
    
    		ChangeLinePart(start, end, element => element.TextRunProperties.SetForegroundBrush(Brushes.Red));
    	}
    }
