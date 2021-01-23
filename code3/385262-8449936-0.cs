    /// <summary>
        /// Do not activate the window just show it
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000008; //WS_EX_TOPMOST 
                return cp;
            }
        } 
