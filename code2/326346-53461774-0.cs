    namespace Draw
    {
    /// <summary>
	/// Controls use of all the cursors in the app, supports loading from strongly typed resources, and caches all references for the lifetime of the app.
	/// </summary>
	public static class Cursors
	{
		// Cache of already loaded cursors
		private static ConcurrentDictionary<byte[], Cursor> cache = new ConcurrentDictionary<byte[], Cursor>();
		/// <summary>
		/// Returns a cursor given the appropriate id from Resources.Designer.cs (auto-generated from Resources.resx). All cursors are
		/// cached, so do not Dispose of the cursor returned from this function.
		/// </summary>
		/// <param name="cursorResource">The resource of the cursor to load. e.g. Properties.Resources.MyCursor (or byte array from .cur or .ani file)</param>
		/// <returns>The cursor. Do not Dispose this returned cursor as it is cached for the app's lifetime.</returns>
		public static Cursor GetCursor(byte[] cursorResource)
		{
			// Have we already loaded this cursor? Use that.
			if (cache.TryGetValue(cursorResource, out Cursor cursor))
				return cursor;
			// Get a temporary file
			var tmpFile = Utils.GetTempFile();
			try
			{
				// Write the cursor resource to temp file
				File.WriteAllBytes(tmpFile, cursorResource);
				// Read back in from temp file as a cursor. Unlike Cursor(MemoryStream(byte[])) constructor, 
				// the Cursor(Int32 handle) version deals correctly with all cursor types.
				cursor = new Cursor(Win32.LoadCursorFromFile(tmpFile));
				// Update dictionary and return
				cache.AddOrUpdate(cursorResource, cursor, (key, old) => cursor);
				return cursor;
			}
			finally
			{
				// Remove the temp file
				Utils.TryDeleteFile(tmpFile);
			}
		}
	}
    }
