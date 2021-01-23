    /// <summary>
    /// Main thread error handler.
    /// </summary>
	public sealed class ExceptionHandler
	{
		private ExceptionHandler()
		{}
		/// <summary>
		/// Handles an exception on the main thread.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="t"></param>
		public static void OnThreadException(object sender, ThreadExceptionEventArgs t) 
		{
			DialogResult result = DialogResult.Cancel;
			try
			{
				result = ShowThreadExceptionDialog(t.Exception);
			}
			catch
			{
				try
				{
					MessageBox.Show("Fatal Error", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				finally
				{
					Application.Exit();
				}
			}
			// Exits the program when the user clicks Abort.
			if (result == DialogResult.Abort) 
				Application.Exit();
		}
 
		// Creates the error message and displays it.
		private static DialogResult ShowThreadExceptionDialog(Exception e) 
		{
			string errorMsg = "An error occurred please contact the adminstrator with the following information:\n\n";
			errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
			return MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
		}
	}
