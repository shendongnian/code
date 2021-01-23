    public static class StringExtensions
	{
		/// <summary>
		/// Returnes a substring located between a leading substring (head) and following substring(tail).
		/// Return null if head or tail are not part of this string.  
		/// </summary>
		/// <param name="mainString"></param>
		/// <param name="head">leading substring</param>
		/// <param name="tail">following substring</param>
		/// <returns>ubstring located between head and tail</returns>
		public static String Between(this string mainString, string head, string tail)
		{
			int HeadPosition;
			int TailPosition;
			int ResultPosition;
			int ResultLenght;
			//test if mainstring contains head and tail
			if (!mainString.Contains(head) && mainString.Contains(tail))
			{
				return null;
			}
			HeadPosition = mainString.IndexOf(head);
			TailPosition = mainString.IndexOf(tail);
			ResultPosition = HeadPosition + head.Length;
			ResultLenght = TailPosition - ResultPosition;
			return mainString.Substring(ResultPosition, ResultLenght);
		}
	}
