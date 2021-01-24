    public unsafe struct File_element
    {
        ....
        public string LineString
	    {
		    get	
		    {		
			    fixed (byte* p = Line)		
			    	return new string((sbyte*)p);
		    }
	    }
    }
    f.Line_no = 0x373635;
    Console.WriteLine(f.LineString); //567
