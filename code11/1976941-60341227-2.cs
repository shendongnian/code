    public class SectionData
    {
    	public string Text { get; set; }
    }
    
    public class SectionHeaderData : SectionData
    {
    	public int Level { get; set; }
    }
    
    public class SectionParagraphData: SectionData { }
