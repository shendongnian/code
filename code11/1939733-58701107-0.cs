        /// <summary>
        /// Use this to safely perform an action which involves any of the properties of the VM.
        /// </summary>
        /// <param name="operation"></param>
        public static void SafeOperationToGuiThread(Action operation)
        {
            System.Windows.Application.Current?.Dispatcher?.Invoke(operation);
        }
