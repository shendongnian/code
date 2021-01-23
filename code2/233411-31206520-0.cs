    /// <summary>
    /// Extends the system menu of a window with additional commands.
    /// Adapted from:
    /// https://github.com/dg9ngf/FieldLog/blob/master/LogSubmit/Unclassified/UI/SystemMenu.cs
    /// </summary>
    public class SystemMenuExtension
    {
        #region Native methods
        private const int WM_SYSCOMMAND = 0x112;
        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);
        #endregion Native methods
        #region Private data
        private Window window;
        private IntPtr hSysMenu;
        private int lastId = 0;
        private List<Action> actions = new List<Action>();
        private List<CommandInfo> pendingCommands;
        #endregion Private data
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the <see cref="SystemMenu"/> class for the specified
        /// <see cref="Form"/>.
        /// </summary>
        /// <param name="window">The window for which the system menu is expanded.</param>
        public SystemMenuExtension(Window window)
        {
            this.window = window;
            if(this.window.IsLoaded)
            {
                WindowLoaded(null, null);
            }
            else
            {
                this.window.Loaded += WindowLoaded;
            }
        }
        #endregion Constructors
        #region Public methods
        /// <summary>
        /// Adds a command to the system menu.
        /// </summary>
        /// <param name="text">The displayed command text.</param>
        /// <param name="action">The action that is executed when the user clicks on the command.</param>
        /// <param name="separatorBeforeCommand">Indicates whether a separator is inserted before the command.</param>
        public void AddCommand(string text, Action action, bool separatorBeforeCommand)
        {
            int id = ++this.lastId;
            if (!this.window.IsLoaded)
            {
                // The window is not yet created, queue the command for later addition
                if (this.pendingCommands == null)
                {
                    this.pendingCommands = new List<CommandInfo>();
                }
                this.pendingCommands.Add(new CommandInfo
                {
                    Id = id,
                    Text = text,
                    Action = action,
                    Separator = separatorBeforeCommand
                });
            }
            else
            {
                // The form is created, add the command now
                if (separatorBeforeCommand)
                {
                    AppendMenu(this.hSysMenu, MF_SEPARATOR, 0, "");
                }
                AppendMenu(this.hSysMenu, MF_STRING, id, text);
            }
            this.actions.Add(action);
        }
        #endregion Public methods
        #region Private methods
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var interop = new WindowInteropHelper(this.window);
            HwndSource source = PresentationSource.FromVisual(this.window) as HwndSource;
            source.AddHook(WndProc);
            this.hSysMenu = GetSystemMenu(interop.EnsureHandle(), false);
            // Add all queued commands now
            if (this.pendingCommands != null)
            {
                foreach (CommandInfo command in this.pendingCommands)
                {
                    if (command.Separator)
                    {
                        AppendMenu(this.hSysMenu, MF_SEPARATOR, 0, "");
                    }
                    AppendMenu(this.hSysMenu, MF_STRING, command.Id, command.Text);
                }
                this.pendingCommands = null;
            }
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SYSCOMMAND)
            {
                if ((long)wParam > 0 && (long)wParam <= lastId)
                {
                    this.actions[(int)wParam - 1]();
                }
            }
            return IntPtr.Zero;
        }
        #endregion Private methods
        #region Classes
        private class CommandInfo
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public Action Action { get; set; }
            public bool Separator { get; set; }
        }
        #endregion Classes
