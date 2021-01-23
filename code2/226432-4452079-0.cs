        public event EventHandler ApplyChanges;
        protected virtual void OnApplyChanges(EventArgs e) {
            var handler = ApplyChanges;
            if (handler != null) handler(this, e);
        }
        private void OKButton_Click(object sender, EventArgs e) {
            OnApplyChanges(EventArgs.Empty);
            this.DialogResult = DialogResult.OK;
        }
        private void ApplyButton_Click(object sender, EventArgs e) {
            OnApplyChanges(EventArgs.Empty);
        }
