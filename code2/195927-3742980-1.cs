        protected override void SetVisibleCore(bool value) {
            if (!this.IsHandleCreated) {
                value = false;
                CreateHandle();
            }
            base.SetVisibleCore(value);
        }
