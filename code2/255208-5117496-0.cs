        static void Main(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			string str = string.Empty;
			for (int i = 0; i < 3001; i++)
				sb.Append("a");
			str = sb.ToString();
			ArrayList arrayList = new ArrayList();
			int length = str.Length;
			int size = 500;
			int start = 0;
			while (length > 0)
			{
				if (length >= size)
					arrayList.Add(str.Substring(start, size));
				else
					arrayList.Add(str.Substring(start, length));
				start += size;
				length -= size;
			}
			Console.Write(arrayList[0].ToString());
		}
