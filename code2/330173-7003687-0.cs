        protected override void SetVisibleCore(bool value) {
            if (!IsHandleCreated && value) {
                base.CreateHandle();
                value = false;
            }
            base.SetVisibleCore(value);
        }
