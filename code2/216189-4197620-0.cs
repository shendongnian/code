		string[] InputSpeeds = new[] { "279\"", "30\"", "5\"", "3.2\"", "1.6\"", "1.3\"", "1\"", "1/1.3", "1/1.6", "1/2", "1/2.5", "1/3", "1/4", "1/5", "1/8", "1/13", "1/8000", "1/16000" };
		List<float> OutputSpeeds = new List<float>();
		foreach (string s in InputSpeeds)
		{
			float ConvertedSpeed;
			if (s.Contains("\""))
			{
				float.TryParse(s.Replace("\"", String.Empty), out ConvertedSpeed);
				OutputSpeeds.Add(ConvertedSpeed);
			}
			else if (s.Contains("1/"))
			{
				float.TryParse(s.Remove(0, 2), out ConvertedSpeed);
				if (ConvertedSpeed == 0)
				{
					OutputSpeeds.Add(0F);
				}
				else
				{
					OutputSpeeds.Add(1 / ConvertedSpeed);
				}
			}
			else
			{
				float.TryParse(s, out ConvertedSpeed);
				OutputSpeeds.Add(ConvertedSpeed);
			}
		}
