    int _textBoxCount;
    ... // your click handler
        this.Controls.Add(NewTB);
        _textBoxCount++;
    ...
    
    protected override Object SaveViewState()
    {
        ViewState["textBoxCount"] = _textBoxCount;
        base.SaveViewState();
    }
    
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        _textBoxCount = ViewState["textBoxCount"];
        for(int i=0; i<_textBoxCount; i++) {
            this.Controls.Add(new TextBox());
        }
    }
    
