    public class Document
    {
    	public int Id {get;set;}
    	public int NestedDocsCount => NestedDocs?.Count;
    	public List<NestedDoc> NestedDocs {get;set;}
    }
