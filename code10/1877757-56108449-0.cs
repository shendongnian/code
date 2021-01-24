    public class Data
		{
			// ~ctors
			public Data()
			{
				Jmeno = "";
				Cislo = "";
				Pritomen = false;
			}
			public BindingList<Data> NaplnData(SVJschuze svJschuze, BindingList<Data> dataList)
			{
				
				foreach (var jednotka in svJschuze.Jednotky)
				{
					foreach (var vlastnik in jednotka.VlastniciJednotky)
					{
						Data data = new Data();
						data.Cislo = jednotka.CisloJednotky;
						data.Jmeno = vlastnik.Jmeno;
						dataList.Add(data);
					}
				}
				return dataList;
			}
			// Fields and properties
			public string Jmeno { get; set; }
			public string Cislo { get; set; }
			public bool Pritomen { get; set; }
		}
