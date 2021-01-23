		public static string URLEncode(string tekst)
		{
			byte[] t = Encoding.UTF8.GetBytes(tekst);
			string s = "";
			for (int i = 0; i < t.Length; i++)
			{
				byte b = t[i];
				int ib = Convert.ToInt32(b);
				if (ib < 46 || ib > 126)
				{
					s += "%" + ib.ToString("x");
				}
				else
				{
					s += Convert.ToChar(b);
				}
			}
			return s;
		}  
