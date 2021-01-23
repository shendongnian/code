		public class Person
		{
		    [JsonConverter(typeof(ProfessionConverter))]
		    public IProfession Profession { get; set; }
		}
