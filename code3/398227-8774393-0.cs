    public void Foo(string path, string data)
    {
    	if (!File.Exists(path))
    		File.Create(path);
    		
    		using (var sw = new StreamWriter(path, false))
    		{
    			// Work your magic.
    			sw.Write();
    		}
    }
