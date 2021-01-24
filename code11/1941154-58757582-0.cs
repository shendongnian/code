public string CourseName
{
	get { return courseName; }
	set
	{
		if (value != null && (value.Length > 50))
		{
			Console.WriteLine("You have typed more than 50 characters");
		}
		else
		{
			courseName = value;
		}
	}
}
