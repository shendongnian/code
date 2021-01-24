	public static string next_Version(string user_input)
	{
		try
		{
			int[] values = user_input.Split(".".ToCharArray()).Select(s => Convert.ToInt32(s)).ToArray();
			bool carryover;
			int index = values.Length - 1;
			do
			{
				carryover = false;
				values[index]++;
				if ((index > 0) && (values[index] == 10))
				{
					values[index] = 0;
					carryover = true;
					index--;
				}
			} while (carryover && (index >= 0));
			return String.Join(".", values);
		}
		catch (Exception)
		{
			return "[ Invalid Version Input! ]";
		}
	}
