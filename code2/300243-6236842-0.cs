    protected override object SaveViewState()
    {
        if (!this.SaveTextViewState)
        {
            // This means the Text property will not be saved to ViewState
            this.ViewState.SetItemDirty("Text", false);
        }
        return base.SaveViewState();
    }
