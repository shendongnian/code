    	protected String _GetResourceName( String[] zSegments )
		{
			// Initialize the resource string to return.
			String zResource = String.Empty;
			// Initialize the variables for the dot- and find position.
			int iDotPos, iFindPos;
			// Loop through the segments of the provided Uri.
			for ( int i = 0; i < zSegments.Length; i++ )
			{
				// Find the first occurrence of the dot character.
				iDotPos = zSegments[i].IndexOf( '.' );
				// Check if this segment is a folder segment.
				if ( i < zSegments.Length - 1 )
				{
					// A dash in a folder segment will cause each following dot occurrence to be appended with an underscore.
					if (( iFindPos = zSegments[i].IndexOf( '-' )) != -1 && iDotPos != -1 )
					{
						zSegments[i] = zSegments[i].Substring( 0, iFindPos + 1 ) + zSegments[i].Substring( iFindPos + 1 ).Replace( ".", "._" );
					}
					// A dash is replaced with an underscore when no underscores are in the name or a dot occurrence is before it.
					//if (( iFindPos = zSegments[i].IndexOf( '_' )) == -1 || ( iDotPos >= 0 && iDotPos < iFindPos ))
					{
						zSegments[i] = zSegments[i].Replace( '-', '_' );
					}
				}
				// Each slash is replaced by a dot.
				zResource += zSegments[i].Replace( '/', '.' );
			}
			// Return the assembly name with the resource name.
			return String.Concat( _zAssemblyName, zResource );
		}
    		
