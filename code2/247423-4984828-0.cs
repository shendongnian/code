    public class ImageMagickCOM
	{
		// Fields, methods and DllImport from the code provided in the question has been omitted
		[DllImport( "kernel32.dll", BestFitMapping = true, CharSet = CharSet.Ansi )]
		static extern bool WriteFile( IntPtr file, StringBuilder buffer,
			uint numberOfBytesToWrite, out uint numberOfBytesWritten, [In] ref NativeOverlapped overlapped );
		public ImageMagickCOM()
		{
			// The code provided in the question is omitted
			// Write message to Console.Error
			string errorMessage = "An error message goes here";
			Console.Error.WriteLine( errorMessage );
			// Write message using new StdErr handle
			var messageBuilder = new StringBuilder( errorMessage );
			uint writtenCount;
			var overlapped = new NativeOverlapped();
			overlapped.OffsetHigh = -1;
			overlapped.OffsetLow = -1;
			WriteFile( handle, messageBuilder, (uint) messageBuilder.Length, out writtenCount, ref overlapped );
		}
	}
