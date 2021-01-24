	double ProgressedMegabytes = 1.5;
	string ProgressBarMegabyte = "83345603 .....................";
		
	ProgressBarMegabyte = (Int32.Parse(ProgressBarMegabyte.TrimEnd('.')) + ProgressedMegabytes).ToString();
		
	Console.WriteLine(ProgressBarMegabyte); // 83345604.5
