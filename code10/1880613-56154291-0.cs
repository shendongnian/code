	[UnmanagedFunctionPointer( CallingConvention.Cdecl )]
	delegate void pfnTaskCallback( int hResult );
	[DllImport( "my.dll" )]
	static extern void launch( [MarshalAs( UnmanagedType.FunctionPtr )] pfnTaskCallback completed );
	public static async Task runAsync()
	{
		var tcs = new TaskCompletionSource<bool>();
		pfnTaskCallback pfn = delegate ( int hr )
		{
			if( hr >= 0 )   // SUCEEDED
				tcs.SetResult( true );
			else
				tcs.SetException( Marshal.GetExceptionForHR( hr ) );
		};
		var gch = GCHandle.Alloc( pfn, GCHandleType.Normal );
		try
		{
			launch( pfn );
			await tcs.Task;
		}
		finally
		{
			gch.Free();
		}
	}
