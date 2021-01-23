        protected override void SetVisibleCore(bool value) {
            if (!this.IsHandleCreated) {
                this.CreateHandle();
                value = false;   // Prevent window from becoming visible
            }
            base.SetVisibleCore(value);
        }
