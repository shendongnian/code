    using System;
    using System.Windows.Forms;
    public static class Extensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="this">The control responsible for performing the <param ref="code" /></param>
        /// <param name="code">The Action to be performed on the Control.</param>
        public static void UIThread(this Control @this, Action code)
        {
            // Check for error
            if (@this == null || !@this.IsHandleCreated || @this.IsDisposed)
            { return; }
            // Execute code
            if (@this.InvokeRequired)
            { @this.BeginInvoke(code); }
            else { code.Invoke(); }
        }
        /// <summary>
        /// Executes the Action on the UI thread, blocks execution on the calling thread until Action has been completed.
        /// </summary>
        /// <param name="this">The control responsible for performing the <param ref="code" /></param>
        /// <param name="code">The Action to be performed on the Control.</param>
        public static void UIThreadInvoke(this Control @this, Action code)
        {
            // Check for error
            if (@this == null || !@this.IsHandleCreated || @this.IsDisposed)
            { return; }
            // Execute code
            if (@this.InvokeRequired)
            { @this.Invoke(code); }
            else { code.Invoke(); }
        }
    }
