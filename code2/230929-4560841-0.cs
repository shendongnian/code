    	private void ReadToEnd()
		{
			string nextLine;
			while ((nextLine = stream.ReadLine()) != null)
			{
                 output.WriteLine(nextLine);
			}
		}
