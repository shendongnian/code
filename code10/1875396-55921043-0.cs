	void Main()
	{
		var listOne = new List<dings>{
			new dings() {id = 1, name = "aaa"},
			new dings() {id = 2, name = "bbb"},
			new dings() {id = 3, name = "ccc"},
		};
	
		var listTwo = listOne.Select(x => new bums() 
			{
				idbums = x.id + 33, 
				namebums = x.name + "hoho"
			}
		).ToList();
	}
	
	public class dings{
		public int id;
		public string name;
	}
	
	public class bums
	{
		public int idbums;
		public string namebums;
	}
