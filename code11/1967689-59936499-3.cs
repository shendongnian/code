    public class MpttModel
    {
        public int MpttModelId { get; set; }
    	
    	public int? ParentId { get; set; }
    	
    	[ForeignKey("ParentId")]
    	public virtual MpttModel Parent { get; set; }
    
    	public virtual ICollection<MpttModel> Children { get; set; }
    }
