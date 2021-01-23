    [Test]
		public void TestSpintaxRandom()
		{
			spintaxParser("{|||{|||{|||{|||{|||{|||{|||{|||}}}}}}}}", new Random());
		}
		public String spintaxParser(String s, Random r)
		{
			if (s.Contains('{'))
			{
				var closingBracePosition = s.IndexOf('}');
				var openingBracePosition = closingBracePosition;
				while (!s[openingBracePosition].Equals('{'))
					openingBracePosition--;
				var spintaxBlock = s.Substring(openingBracePosition, closingBracePosition - openingBracePosition + 1);
				var items = spintaxBlock.Substring(1, spintaxBlock.Length - 2).Split('|');
				var next = r.Next(items.Length);
				Console.WriteLine(next);
				s = s.Replace(spintaxBlock, items[next]);
				return spintaxParser(s, r);
			}
			return s;
		}
