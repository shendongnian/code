    public int SampleCB ( double sampleTime, IMediaSample mediaSample )
    {
    	Console.WriteLine ( "SampleCB Callback" );
    	Console.WriteLine ( mediaSample.IsSyncPoint ( ) + " " );
    
            /* other code */
    	Marshal.ReleaseComObject ( mediaSample );
    	return 0;
    }
