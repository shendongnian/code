    public void SeekMethod(int[] lineNos)
    {
    	string line = null;
        long step;
    
    	Array.Sort(lineNos);
    
    	Debug.Print("");
    	Debug.Print("Line No\t\tPosition\t\tLine");
    	Debug.Print("-------\t\t--------\t\t-----------------");
    
    	using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
    	{
    		foreach (int lineNo in lineNos)
    		{
    			StreamReader reader = new StreamReader(fs);
    			step = (lineNo - 1) * LineLength - fs.Position;
                fs.Position += step;
    			
    			if ((line = reader.ReadLine()) != null) {
    				Debug.Print("{0}\t\t\t{1}\t\t\t\t{2}", lineNo, step, line);
    			}
    		}
    	}
    }
