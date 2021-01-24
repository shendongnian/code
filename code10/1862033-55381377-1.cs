    private NotifyTask _OmmaLicenseNumberChangedNotifyTask
        = NotifyTask.Create(Task.CompletedTask);
    public NotifyTask OmmaLicenseNumberChangedNotifyTask
    {
        get => this._OmmaLicenseNumberChangedNotifyTask;
        set
        {
            if (value != null)
            {
                this._OmmaLicenseNumberChangedNotifyTask = value;
                OnPropertyChanged("OmmaLicenseNumberChangedNotifyTask");
            }
        }
    }
    public string OmmaLicenseNumber
    {
        get => _ommaLicenseNumber;
        set
        {
            Set(() => OmmaLicenseNumber, ref _ommaLicenseNumber, value);
            Patient.OmmaLicenseNumber = value;
            OmmaLicenseNumberChangedNotifyTask = NotifyTask.Create(CheckLicenseValid());
        }
    }
