    public void SeekMethod(int[] lineNos)
    {
    	long totalPosition = 0, position = 0;
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
    			position = (lineNo - 1) * LineLength - totalPosition;
    			
    			fs.Seek(position, SeekOrigin.Current);
    			totalPosition = fs.Position;
    
    			if ((line = reader.ReadLine()) != null) {
    				Debug.Print("{0}\t\t\t{1}\t\t\t\t{2}", lineNo, position, line);
    				fs.Position = totalPosition;
    			}
    		}
    	}
    }
