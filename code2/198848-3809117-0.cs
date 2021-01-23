    public void AddItemVersion(ItemVersion itemVersion)
    {
        ItemVersions.Add(itemVersion);
        itemVersion.Item = this;
    }
