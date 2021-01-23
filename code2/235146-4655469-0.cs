	public class ListItem : IComparable<ListItem>
	{
		public int RollNumber { get; set; }
		public string Name { get; set; }
		public string AdmissionCode { get; set; }
		private static readonly char[] Numbers = new[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9'
		};
		#region Implementation of IComparable<in ListItem>
		public int CompareTo(ListItem other)
		{
			// Assumes AdmissionCode is in ####ABC format,
			// with at least one number and any amount of letters.
			string myNumberPart, myRemainingPart;
			string otherNumberPart, otherRemainingPart;
			SplitAdmissionCode(AdmissionCode, out myNumberPart, out myRemainingPart);
			SplitAdmissionCode(other.AdmissionCode, out otherNumberPart, out otherRemainingPart);
			int myNumber = int.Parse(myNumberPart);
			int otherNumber = int.Parse(otherNumberPart);
			int result = myNumber.CompareTo(otherNumber);
			// Numbers are different.
			if (result != 0)
				return result;
			// Numbers are same. Use text compare for the remaining part.
			return myRemainingPart.CompareTo(otherRemainingPart);
		}
		private void SplitAdmissionCode(string code, out string numbersPart, out string remainingPart)
		{
			int lastNumberIndex = code.LastIndexOfAny(Numbers);
			numbersPart = code.Substring(0, lastNumberIndex + 1);
			if (lastNumberIndex == code.Length - 1)
				remainingPart = "";
			else
				remainingPart = code.Substring(lastNumberIndex + 1);
		}
		#endregion
	}
