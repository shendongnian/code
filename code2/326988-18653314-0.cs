        /// <summary>
        /// Set a custom panes position in the undocked state.
        /// </summary>
        /// <param name="customTaskPane">The custom task pane.</param>
        /// <param name="x">The new X position.</param>
        /// <param name="y">The new Y position.</param>
        private void SetCustomPanePositionWhenFloating(CustomTaskPane customTaskPane, int x, int y)
        {
            var oldDockPosition = customTaskPane.DockPosition;
            var oldVisibleState = customTaskPane.Visible;
            customTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionFloating;
            customTaskPane.Visible = true; //The task pane must be visible to set its position
            var window = FindWindowW("MsoCommandBar", customTaskPane.Title); //MLHIDE
            if (window == null) return;
            WinApi.MoveWindow(window, x, y, customTaskPane.Width, customTaskPane.Height, true);
            customTaskPane.Visible = oldVisibleState;
            customTaskPane.DockPosition = oldDockPosition;
        }
        [DllImport("user32.dll", EntryPoint = "FindWindowW")]
        public static extern System.IntPtr FindWindowW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lpClassName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool MoveWindow([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bRepaint);
        /// <summary>
        /// Set a custom panes size in the undocked state.
        /// </summary>
        /// <param name="customTaskPane">The custom task pane.</param>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        private void SetCustomPaneSizeWhenFloating(CustomTaskPane customTaskPane, int width, int height)
        {
            var oldDockPosition = customTaskPane.DockPosition;
            customTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionFloating;
            customTaskPane.Width = width;
            customTaskPane.Height = height;
            customTaskPane.DockPosition = oldDockPosition;
        }
