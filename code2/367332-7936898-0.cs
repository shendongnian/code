            string text = "sentence one. sentence two? sentence three...";
			List<string> sentences = new List<string>();
			
			StringBuilder sb = new StringBuilder();
			bool termHit = false;
			
			foreach (char c in text)
			{
				sb.Append(c);
				
				if (c == '.' || c == '?')
				{
					termHit = true;		
				}
				else
				{
					if (termHit)
					{
						termHit = false;
						sentences.Add(sb.ToString());
						sb = new StringBuilder();
					}
				}
			}
			
			if (sb.Length > 0)
			{
				sentences.Add(sb.ToString());	
			}
			
			Console.WriteLine("Parse:");
			foreach (string sentence in sentences)
			{
				Console.WriteLine(sentence);	
			}
			
			string[] splits = text.Split(new char[] {'.', '?'});
			
			Console.WriteLine("Split:");
			foreach (string sentence in splits)
			{
				Console.WriteLine(sentence);	
			}
