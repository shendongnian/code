    set
    {
        SettingChangingEventArgs e = new SettingChangingEventArgs(propertyName, base.GetType().FullName, this.SettingsKey, value, false);
        this.OnSettingChanging(this, e);
        if (!e.Cancel)
        {
            base[propertyName] = value;
            PropertyChangedEventArgs args2 = new PropertyChangedEventArgs(propertyName);
            this.OnPropertyChanged(this, args2);
        }
    }
