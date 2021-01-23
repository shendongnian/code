     public override void Load()
    {
        myViewState.Load();
        var pair = (Pair)this.StateFormatter.Deserialize(myViewState.Value);
        this.ViewState = pair.First;
        this.ControlState = pair.Second;
    }
    public override void Save()
    {
        myViewState.Value = this.StateFormatter.Serialize(new Pair(this.ViewState, this.ControlState));
        myViewState.Save();
    }
