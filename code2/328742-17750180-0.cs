    internal class MouseFilter : IMessageFilter
    {
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_MOUSEMOVE = 0x0200;
        /// <summary>
        ///     Filtert eine Meldung, bevor sie gesendet wird.
        /// </summary>
        /// <param name="m">Die zu sendende Meldung. Diese Meldung kann nicht geändert werden.</param>
        /// <returns>
        ///     true, um die Meldung zu filtern und das Senden zu verhindern. false, um das Senden der Meldung bis zum nächsten Filter oder Steuerelement zu ermöglichen.
        /// </returns>
        public bool PreFilterMessage(ref Message m)
        {
            Point mousePosition = Control.MousePosition;
            var args = new MouseFilterEventArgs(MouseButtons.Left, 0, mousePosition.X, mousePosition.Y, 0);
            switch (m.Msg)
            {
                case WM_MOUSEMOVE:
                    if (MouseFilterMove != null)
                    {
                        MouseFilterMove(Control.FromHandle(m.HWnd), args);
                    }
                    break;
                case WM_LBUTTONDOWN:
                    if (MouseFilterDown != null)
                    {
                        MouseFilterDown(Control.FromHandle(m.HWnd), args);
                    }
                    break;
                case WM_LBUTTONUP:
                    if (MouseFilterUp != null)
                    {
                        MouseFilterUp(Control.FromHandle(m.HWnd), args);
                    }
                    break;
            }
            // Always allow message to continue to the next filter control
            return args.Handled;
        }
        /// <summary>
        ///     Occurs when [mouse filter up].
        /// </summary>
        public event MouseFilterEventHandler MouseFilterUp;
        /// <summary>
        ///     Occurs when [mouse filter down].
        /// </summary>
        public event MouseFilterEventHandler MouseFilterDown;
        /// <summary>
        ///     Occurs when [mouse filter move].
        /// </summary>
        public event MouseFilterMoveEventHandler MouseFilterMove;
    }
    internal delegate void MouseFilterEventHandler(object sender, MouseFilterEventArgs args);
    internal delegate void MouseFilterMoveEventHandler(object sender, MouseFilterEventArgs args);
    internal class MouseFilterEventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseFilterEventArgs" /> class.
        /// </summary>
        /// <param name="mouseButton">The mouse button.</param>
        /// <param name="clicks">The clicks.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="delta">The delta.</param>
        public MouseFilterEventArgs(MouseButtons mouseButton, int clicks, int x, int y, int delta)
        {
            Button = mouseButton;
            Clicks = clicks;
            X = x;
            Y = y;
            Delta = delta;
            Handled = false;
        }
        /// <summary>
        ///     Gets or sets the button.
        /// </summary>
        /// <value>
        ///     The button.
        /// </value>
        public MouseButtons Button { get; set; }
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="MouseFilterEventArgs" /> is handled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if handled; otherwise, <c>false</c>.
        /// </value>
        public bool Handled { get; set; }
        /// <summary>
        ///     Gets or sets the X.
        /// </summary>
        /// <value>
        ///     The X.
        /// </value>
        public int X { get; set; }
        /// <summary>
        ///     Gets or sets the Y.
        /// </summary>
        /// <value>
        ///     The Y.
        /// </value>
        public int Y { get; set; }
        /// <summary>
        ///     Gets or sets the clicks.
        /// </summary>
        /// <value>
        ///     The clicks.
        /// </value>
        public int Clicks { get; set; }
        /// <summary>
        ///     Gets or sets the delta.
        /// </summary>
        /// <value>
        ///     The delta.
        /// </value>
        public int Delta { get; set; }
    }
