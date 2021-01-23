        private bool initialized = false;
        protected override void OnLoad(EventArgs e) {
            if (!initialized) {
                initialized = true;
                // etc...
            }
            base.OnLoad(e);
        }
