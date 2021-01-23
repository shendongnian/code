	using System;
	using System.IO;
	using System.Windows.Forms;
	public void ParseFile(string filepath)
	{
		TextReader reader = null;
		try
		{
			reader = new StreamReader(filepath);
			string line = reader.ReadLine();
			while (!string.IsNullOrEmpty(line))
			{
				try
				{
					// parse line here; if line is malformed, 
					// general exception will be caught and ignored
					// and we move on to the next line
				}
				catch (Exception)
				{
					// recommended to at least log the malformed 
					// line at this point
				}
				line = reader.ReadLine();
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Exception when trying to open or parse file", ex);
		}
		finally
		{
			if (reader != null)
			{
				reader.Close();
				reader.Dispose();
			}
			reader = null;
		}
	}
