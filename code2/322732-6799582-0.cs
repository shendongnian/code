    internal virtual void LoadRecursive()
    {
        if (this._controlState < ControlState.Loaded) {
            if (this._adapter != null) {
                this._adapter.OnLoad(EventArgs.Empty);
            } else {
                this.OnLoad(EventArgs.Empty);  // ** Here. **
            }
        }
        if (this._occasionalFields != null
            && this._occasionalFields.Controls != null) {
            string collectionReadOnly
                = this._occasionalFields.Controls.SetCollectionReadOnly(
                    "Parent_collections_readonly");
            int count = this._occasionalFields.Controls.Count;
            for (int i = 0; i < count; i++) {
                this._occasionalFields.Controls[i].LoadRecursive();
            }
            this._occasionalFields.Controls.SetCollectionReadOnly(
                collectionReadOnly);
        }
        if (this._controlState < ControlState.Loaded) {
            this._controlState = ControlState.Loaded;
        }
    }
