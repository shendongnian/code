    public bool AreSettingChanged()
    {
        return objRpmButtonHolder.RpmButtonCollection.Exists(btn
            => { return btn.IsChanged; });
    }
