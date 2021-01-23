    virtual public bool SetAssetGroup(AssetGroup group)
    {
        this.AssetGroup = group;
        group.Assets.Add(this);
    }
