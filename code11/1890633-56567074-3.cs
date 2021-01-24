	void Main()
	{
		List<string> l = new List<string>()
		{
			"ViewIt - View Data - selected Key is: client1",
			"ViewIt - View Data - selected Substance is: vodka",
			"ViewIt - View Data - selected Region is: Russia",
			"ViewIt - View Data - selected Area is: Moscow",
			"ViewIt - View Data - selected Key is: client2",
			"ViewIt - View Data - selected Substance is: Essex",
			"ViewIt - View Data - selected Region is: England",
			"ViewIt - View Data - selected Area is: Essex",
			"ViewIt - View Data - selected Key is: client3",
			"ViewIt - View Data - selected Substance is: IceTea",
			"ViewIt - View Data - selected Region is: US",
			"ViewIt - View Data - selected Area is: New York"
		};
		List<DATA> datalist = new List<UserQuery.DATA>();
		l.Where(w=> w.Contains("View Data")).Select((v, i) => new { Index = i, Value = v })
			.GroupBy(x => x.Index / 4)
			.ToList().ForEach(r => {
					datalist.Add(parseStrings(r.Select(v=>v.Value).ToList()));
			});
		Console.Write(datalist);
	}
	public DATA parseStrings(List<string> list){
		
		DATA d = new DATA();
		list.ForEach(f => {
			var row = f.Substring(f.IndexOf("selected") + 9)
			.Split(':');
			
			switch (row[0].TrimEnd(" is".ToCharArray()).ToLower())
			{
				case "key":
					d.Key = row[1].ToString().TrimStart(' ');
					break;
				case "substance":
					d.Substance = row[1].ToString().TrimStart(' ');
					break;
				case "region":
					d.Region = row[1].ToString().TrimStart(' ');
					break;
				case "area":
					d.Area = row[1].ToString().TrimStart(' ');
					break;
				default:
					break;
			}
		});
		
		
		return d;
	}
	public class DATA{
		public string Key {get;set;}
		public string Substance {get;set;}
		public string Region {get;set;}
		public string Area {get;set;}
		public DATA(){}
	}
