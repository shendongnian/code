    virtual public bool AddAsset(Asset asset)
    {
        if (asset != null && _assets.Add(asset))
        {
            asset.AssetGroup = this;
            return true;
        }
        return false;
    }
    
    ... and a corresponding remove
