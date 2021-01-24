    public class Program
    {
        public static void Main(string[] args)
        {
            CreateMaps();
			
			Lender src = new Lender()
			{
				Id = 1,
				Name = "Bob",
				ClaimTypes = ClaimType.A | ClaimType.C
			};
			
			LenderServiceModel dest = Mapper.Map<LenderServiceModel>(src);
			
			Console.WriteLine("{0}: {1}", dest.Id, dest.Name);
			
			foreach(var claimType in dest.ClaimTypes)
			{
				Console.WriteLine(claimType);
			}
        }
		
		private static void CreateMaps()
		{
			Mapper.CreateMap<Lender, LenderServiceModel>()
				.ForMember(dest => dest.ClaimTypes, opts => opts.MapFrom(src =>
			        src.ClaimTypes.ToString().Split(new string[]{", "}, StringSplitOptions.None).ToList()));
		}
    }
	[Flags]
	public enum ClaimType : int
    {
        A = 1,
        B = 2,
        C = 4
    }
	
	public class Lender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClaimType ClaimTypes { get; set; }
	}
	
	public class LenderServiceModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ClaimTypes { get; set; }
    }
