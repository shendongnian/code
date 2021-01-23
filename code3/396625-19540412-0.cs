    internal static class ExtensionMethods
    {
        /// <summary>
        /// Updates the label text while being used in a multithread app.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="text">The text.</param>
        internal static void UpdateThreadedText(this Label control, string text)
        {
            Action action = () => control.Text = text;
            control.Invoke(action);
        }
        /// <summary>
        /// Refreshes the threaded.
        /// </summary>
        /// <param name="control">The control.</param>
        internal static void RefreshThreaded(this Label control)
        {
            Action action = control.Refresh;
            control.Invoke(action);
        }
    }
