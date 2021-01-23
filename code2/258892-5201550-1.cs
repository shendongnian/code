    public void SeekMethod(int[] lineNos)
    {
    	string line = null;
    
    	Array.Sort(lineNos);
    
    	Debug.Print("");
    	Debug.Print("Line No\t\tPosition\t\tLine");
    	Debug.Print("-------\t\t--------\t\t-----------------");
    
    	using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
    	{
    		foreach (int lineNo in lineNos)
    		{
    			StreamReader reader = new StreamReader(fs);
    			fs.Position = (lineNo - 1) * LineLength;
    			
    			if ((line = reader.ReadLine()) != null) {
    				// The fs.Position doesn't give your incremental position, not sure
    				// how important that is
    				Debug.Print("{0}\t\t\t{1}\t\t\t\t{2}", lineNo, fs.Position, line);
    			}
    		}
    	}
    }
