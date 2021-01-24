    public object ExecScalar(OdbcCommand cmd, bool async = true) {
			try {
				Enable(async);
				// Create new scalar object
				object obj = cmd.ExecuteScalar();
				// Check value cast is OK for Int
				return (obj != null)
					? GetStatusOuput(this, cmd, obj)
					: null;
			}
			catch {
				throw;
			}
			finally {
				Disable();
			}
		}
		private object GetStatusOuput(Network network, OdbcCommand command, object value) {
			network.DoLog(
				command.CommandText
			);
			return value;
		}
