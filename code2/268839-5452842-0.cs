		public static void Main(string[] args)
		{
			var pts = from x in Enumerable.Range(0, 24)
				      from y in Enumerable.Range(0, 11)
					  select new byte[] { (byte) x, (byte) y };
					  
			foreach (var pt in pts.OrderBy(pt => pt.ToMD5()))
				Console.WriteLine("(x,y) {0},{1} : {2}", pt[0], pt[1], pt.ToMD5());
		}
