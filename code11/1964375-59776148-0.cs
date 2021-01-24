	public class CandidateJson
	{
		public Response response { get; set; }
	}
	public class Response
	{
		public Result result { get; set; }
		public string uri { get; set; }
	}
	public class Result
	{
		public Candidate Candidates { get; set; }
	}
	public class Candidate 
	{
		public List<Row> row { get; set; }
	}
	public class Row
	{
		public string no { get; set; }
		public List<FL> FL { get; set; }
	}
	public class FL
	{
		public string val { get; set; }
		public string content { get; set; }
	}
