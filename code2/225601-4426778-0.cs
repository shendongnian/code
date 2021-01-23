	string input = "...";
	StringBuilder output = new StringBuilder();
	var handle = System.Runtime.InteropServices.GCHandle.Alloc(output, GCHandleType.Pinned);
	try
	{
		CreateHash(input, output);
	}
	finally
	{
		handle.Free();
	}
