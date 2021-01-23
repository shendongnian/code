	string[] output_lines; // presumably holds the output of df
	for (int i = 0; i < output_lines.Length; i++)
	{
		if (i == 0)
			continue;
		string[] b_u = output_lines[i].Split(" ");
		string blocks = b_u[0];
		string used = b_u[1];
	}
