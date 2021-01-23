			string s ="section[]=100&section[]=200&section[]=300&section[]=400";
			Regex r = new Regex(@"section\[\]=([0-9]+)(&|$)");
			
			List<int> v = new List<int>();
			
			Match m=r.Match(s);
			while (m.Success){
				v.Add(Int32.Parse(m.Groups[1].ToString()));
				m=m.NextMatch();
			}
			
			int[]result = v.ToArray();
