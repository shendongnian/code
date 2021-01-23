	public class ResearchPaper
	{
		int StudentID;
		int PaperID;
		string Title;
		sbyte InitialGrade;
		sbyte PeerRating;
		
		public sbyte Grade
		{
			get
			{
				return (InitialGrade + PeerRating);
			}
		}
	}
	public class PaperGrader
	{
		List<ResearchPaper> Papers;
		
		public PaperGrader(List<ResearchPaper> Papers)
		{
			this.Papers = Papers;
		}
		
		public void Vote(int Id)
		{
			foreach (ResearchPaper Paper in Papers)
			{
				if (Paper.PaperID == Id)
				{
					Paper.PeerRating++;
					continue;
				}
				else
				{
					Paper.PeerRating--;
				}
			}
		}
	}
