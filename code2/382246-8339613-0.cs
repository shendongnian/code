    string SEARCH = @" X'D3A8AF";
    int BUFFER = 1024;
    
    int tot = 0;
    using (FileStream fs = new FileStream(filename, FileMode.Open))
    {
    	using (StreamReader sr = new StreamReader(fs))
    	{
    		char[] buffer = new char[BUFFER];
    		int pos = 0;
    		while (fs.Position < fs.Length)
    		{
    			sr.ReadBlock(buffer, 0, BUFFER);
    			string s = new string(buffer);
    			int i = 0;
    			do
    			{
    				i = s.IndexOf(SEARCH, i);
    				if (i >= 0) { tot++; i++; }
    			}
    			while (i >= 0);
    			pos += BUFFER;
    			if (!s.EndsWith(SEARCH)) pos -= SEARCH.Length;
    			fs.Position = pos;
    		}
    		sr.Close();
    	}
    	fs.Close();
    }
