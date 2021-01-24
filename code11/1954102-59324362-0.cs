    private string _settingCode;
    
    [Required(AllowEmptyStrings = true)]
    [StringLength(20)]
    public string SettingCode
    {
        get { return _settingCode; }
        set
        {
            _settingCode = value == null ? string.Empty : value;
        }
    } 
