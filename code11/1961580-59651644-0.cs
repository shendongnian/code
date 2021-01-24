    foreach (var item in _readOrWriteHomingDataHelper.HomingConfiguration)
    {
      HomingItems.Add(new EnumLocalizer<HomingLocationEnums>() { Value = (HomingLocationEnums)Enum.Parse(typeof(HomingLocationEnums), item.Key) }, item.Value);
    }
    
    RaisePropertyChanged(nameof(this.HomingItems));
