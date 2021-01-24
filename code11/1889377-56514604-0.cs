        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    cp.Style |= 0x40000; //WS_SIZEBOX;
                }
                return cp;
            }
        }
