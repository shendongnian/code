    public int compareVersion(string Version1,string Version2)
		{
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"([\d]+)");
			System.Text.RegularExpressions.MatchCollection m1 = regex.Matches(Version1);
			System.Text.RegularExpressions.MatchCollection m2 = regex.Matches(Version2);
			int min = Math.Min(m1.Count,m2.Count);
			for(int i=0; i<min;i++)
			{
				if(Convert.ToInt32(m1[i].Value)>Convert.ToInt32(m2[i].Value))
				{
					return 1;
				}
				if(Convert.ToInt32(m1[i].Value)<Convert.ToInt32(m2[i].Value))
				{
					return -1;
				}				
			}
			return 0;
		}
