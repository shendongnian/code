/// <summary>
/// Creates a path to a unqiue-guid-named .txt file under the <see cref="Path.GetTempPath"/> directory. This does not create the file.
/// </summary>
/// <returns>Path.</returns>
public static string CreateTempGuidTxtFilename()
{
	return string.Format(
		"{0}.txt",
		Path.Combine(
			Path.GetTempPath(),
			Guid.NewGuid().ToString().Replace( '-', '_' ) ) );
}
/// <summary>
/// Attempt to gather the process id for from a remote process start.
/// </summary>
/// <param name="info">Process info.</param>
/// <param name="ip">Remote machine ip.</param>
/// <returns>Process ID if it was successfully found.</returns>
private int? GetRemoteProcessStartId( ProcessStartInfo info, string ip )
{
    // Declare no process id.
	int? processId = null;
	// We are going to start the process and feed the output into a generated .txt file with the given args.
	string processInfoTempGuidPath = CreateTempGuidTxtFilename();
	info.Arguments = string.Format( "{0} > {1} 2>&1 &", info.Arguments, processInfoTempGuidPath );
	// Right, here we go!
	Process psexecProcess = null;
	try
	{
		// Start the process and wait for it to exit!
		psexecProcess = Process.Start( info );
		psexecProcess?.WaitForExit();
		// Now we have exited, we can safely read the generated txt file and search the output.
		// We are attempting to parse the output to find the process ID which was remotely launched
		// since psexec displays this as standard output.
		processId = TryParsePsexecLinesForProcessId( ip, File.ReadAllLines( processInfoTempGuidPath ) );
	}
	catch
	{
		// Any exception and we will try to kill our process.
		processId = null;
		psexecProcess?.Kill();
	}
	finally
	{
		// We finally want to delete the generated .txt file.
		// It may have been created even on a failed process, so be safe!
		if ( File.Exists( processInfoTempGuidPath ) )
		{
			File.Delete( processInfoTempGuidPath );
		}
		psexecProcess?.Close();
	}
	// Return the process id which may or may not be found.
	return processId;
}
/// <summary>
/// Attempt to retrieve the process id from an output of text.
/// </summary>
/// <param name="ip">Machine address.</param>
/// <param name="output">Output.</param>
/// <returns>Process ID if it was parsed successfully.</returns>
public static int? TryParsePsexecLinesForProcessId(string ip, params string[] output)
{
	// Get the queryable string for the line of psexec stream output which contains the remotely started process id.
	string queryId = string.Format( "started on {0} with process ID", ip );
	// Once we have found the line containing the process id query string, 
	// we will reverse and clean it to read the beginning characters which should be the
	// string representation of the remote process id but backwards.
	string reversedQuery = string.Concat(
		output.FirstOrDefault(
			x => x.Contains(
				queryId,
				StringComparison.OrdinalIgnoreCase ) )
				.TrimEnd( '.' ).Reverse() );
	// Take while are parsing the integer, remeber to reverse again since we are backwards!
	// On successfully reading characters, we are going to try and parse for and integer!
	string idToParse = string.Concat( reversedQuery.TakeWhile( x => !char.IsWhiteSpace( x ) ).Reverse() );
	if ( !string.IsNullOrEmpty( idToParse ) && int.TryParse( idToParse, out int remoteProcessId ) )
	{
		return remoteProcessId;
	}
	else
	{
		// Else we can't parse any informative message regarding process id.
		return null;
	}
}
