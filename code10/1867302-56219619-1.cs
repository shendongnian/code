    public class TestReport
    {
    	public int Id { get; set; }
    
    	public int? TestMemberId { get; set; }
    
    	[ForeignKey(nameof(TestMemberId))]
    	public virtual TestMember TestMember { get; set; }
    
    	public DateTime Date { get; set; }
    
    	public bool IsSuccess { get; set; }
    }
