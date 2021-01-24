	int correct = 0;
	int incorrect = 0;     
	if (A.Length == B.Length)
	{
		List<string> Mismatch = new List<string>();
		for(int i = 1; i <= A.Length; i++)
		{
			if (A[i-1] == B[i-1])
			{
				correct++;
			}
			else
			{
				incorrect++;
				Mismatch.Add(i.ToString());
			}
		}
		label1.Text = String.Join(", ", Mismatch);
	}
