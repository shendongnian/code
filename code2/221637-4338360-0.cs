		/// <summary>
		/// Executes the Export of the Schema in the given connection
		/// </summary>
		/// <param name="script"><see langword="true" /> if the ddl should be outputted in the Console.</param>
		/// <param name="export"><see langword="true" /> if the ddl should be executed against the Database.</param>
		/// <param name="justDrop"><see langword="true" /> if only the ddl to drop the Database objects should be executed.</param>
		/// <param name="format"><see langword="true" /> if the ddl should be nicely formatted instead of one statement per line.</param>
		/// <param name="connection">
		/// The connection to use when executing the commands when export is <see langword="true" />.
		/// Must be an opened connection. The method doesn't close the connection.
		/// </param>
		/// <param name="exportOutput">The writer used to output the generated schema</param>
		/// <remarks>
		/// This method allows for both the drop and create ddl script to be executed.
		/// This overload is provided mainly to enable use of in memory databases. 
		/// It does NOT close the given connection!
		/// </remarks>
		public void Execute(bool script, bool export, bool justDrop, bool format,
		                    IDbConnection connection, TextWriter exportOutput)
                -- remainder of method --
