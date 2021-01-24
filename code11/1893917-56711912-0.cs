    public class Sample{
    public int SampleId{ get; set; }
	public string SampleName{ get; set; }
	
	public int? Person_Id { get; set; }	
	[ForeignKey("Person_Id")]
    public Person Sampler { get; set; } 
	}
