	string baseName = current_dir + "\\" + DateTime.Now.ToString("HHmmss") + ".";
	StreamWriter writer = null;
	try
	{
		using (StreamReader inputfile = new System.IO.StreamReader(new_path))
		{
			int count = 0;
			while ((line = inputfile.ReadLine()) != null)
			{
			
				if (writer == null || count > 300)
				{
					count = 0;
					if (writer != null)
					{
						writer.Close();
						writer = null;
					}
					
					writer = new System.IO.StreamWriter(baseName + count.ToString() + ".txt", true);
				}
				
				writer.WriteLine(line.ToLower());
				
				++count;
			}
		}
	}
	finally
	{
		if (writer != null)
			writer.Close();
	}
