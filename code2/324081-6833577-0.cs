	using System;
	using System.Collections.Generic;
	using System.Text;
	
	public class SomeClass
	{
		public static void Main()
		{
			// your collection - make this a class member
			List<double> nums = new List<double>();
			
			// populate array
			nums.Add(227.905);
			nums.Add(227.905);
			nums.Add(242.210);
			nums.Add(-236.135);
			// etc.
			
			// faux user data entry - collect it and validate it a button click handler
			double userNum = 25.305;
			
			// add new value to items in array
			for (int i=0; i<nums.Count; i++) nums[i] += userNum;
			
			// declare string builder for fast string concatenation
			StringBuilder sb = new StringBuilder();
			
			// build output string from nums array
			foreach (double d in nums)
				sb.Append(d.ToString() + System.Environment.NewLine);
			
			// writing to console here but you would do something like:
			//    _myRichEditControlInstance.Text = sb.ToString();
			Console.WriteLine(sb.ToString());
		}
	}
