    public static class TaskHelper
    {
		/// <summary>
		/// Runs a TPL Task fire-and-forget style, the right way - in the background, separate from the current thread, with no risk
		/// of it trying to rejoin the current thread.
		/// </summary>
		/// <param name="fn"></param>
        public static void RunBg(Func<Task> fn)
        {
            #pragma warning disable 4014
            Task.Run(fn).ConfigureAwait(false);
            #pragma warning restore 4014
        }
    }
