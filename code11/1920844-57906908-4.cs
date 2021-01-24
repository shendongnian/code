	public object ExecScalar(OdbcCommand cmd, bool async = true) {
			try {
				Enable(async);
				// Create new scalar object
				object obj = cmd.ExecuteScalar();
				// Run log and fetch obj if !null
				return obj?.AndExecute(() => DoLog(cmd.CommandText));
			}
			catch {
				throw;
			}
			finally {
				Disable();
			}
		}
