    /// <summary>
    /// Demo.
    /// </summary>
    class Program {
    
        /// <summary>
        /// Sent as a signal that a window or an application should terminate.
        /// </summary>
        const uint WM_CLOSE = 0x0010;
    
        /// <summary>
        /// Posts a message to the message queue of the specified thread. It returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="threadId">The identifier of the thread to which the message is to be posted.</param>
        /// <param name="msg">The type of message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostThreadMessage(uint threadId, uint msg, IntPtr wParam, IntPtr lParam);
    
        /// <summary>
        /// Closes a windowless application pointed with process name.
        /// </summary>
        /// <param name="processName">The name of the process to close.</param>
        static void CloseWindowless(string processName) {
            foreach (var process in Process.GetProcessesByName(processName)) {
                using (process) {
                    foreach (ProcessThread thread in process.Threads) PostThreadMessage((uint)thread.Id, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }
    
        /// <summary>
        /// Main application entry point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args) => CloseWindowless("MyAppName");
    
    }
