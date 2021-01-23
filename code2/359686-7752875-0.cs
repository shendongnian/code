        StackTrace st = new StackTrace();
    	for ( int i=0; i<st.FrameCount; i++ )
	{
		StackFrame sf = st.GetFrame(i);
		MethodBase mb = sf.GetMethod();
		// do whatever you want
	}	
